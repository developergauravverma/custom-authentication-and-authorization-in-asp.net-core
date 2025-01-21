using MyApp.DAL.Connection;
using MyApp.DAL.InfraStructure.IRepository;
using MyApp.Models.Models;

namespace MyApp.DAL.InfraStructure.Repository;

public class TokenRepo(AppDbConnection context) : Repository<Token>(context), ITokenRepo
{
    private readonly AppDbConnection _context = context;

    public async Task UpdateToken(Token token)
    {
        await Task.Run(() => _context.Update(token));
    }
}