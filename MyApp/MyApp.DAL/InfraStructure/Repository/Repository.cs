
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyApp.DAL.Connection;
using MyApp.DAL.InfraStructure.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp.DAL.InfraStructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbConnection _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbConnection context)
    {
        this._context = context;
        this._dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllData(List<string?>? IncludeTables = null)
    {
        IQueryable<T> query = _dbSet;
        if (IncludeTables is not null && IncludeTables.Count > 0)
        {
            string tables = string.Join(",", IncludeTables);
            return await query.Include(tables).ToListAsync();
        }
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetDataById(Expression<Func<T, bool>> predicate, List<string?>? IncludeTables = null)
    {
        IQueryable<T> query = _dbSet;
        if (IncludeTables is not null && IncludeTables.Count > 0)
        {
            string tables = string.Join(",",IncludeTables);
            return await query.Include(tables).FirstOrDefaultAsync(predicate);
        }
        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task SaveEntity(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteEntity(T entity)
    {
        await Task.Run(() => { _dbSet.Remove(entity); });
    }
}