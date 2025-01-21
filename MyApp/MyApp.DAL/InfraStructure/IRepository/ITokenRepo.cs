using MyApp.Models.Models;

namespace MyApp.DAL.InfraStructure.IRepository;

public interface ITokenRepo : IRepository<Token>
{
    Task UpdateToken(Token token);
}