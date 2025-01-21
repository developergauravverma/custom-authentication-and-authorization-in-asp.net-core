using System.Linq.Expressions;

namespace MyApp.DAL.InfraStructure.IRepository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllData(List<string?>? IncludeTables = null);
    Task<T?> GetDataById(Expression<Func<T,bool>> predicate, List<string?> IncludeTables = null);
    Task SaveEntity(T entity);
    Task DeleteEntity(T entity);
}