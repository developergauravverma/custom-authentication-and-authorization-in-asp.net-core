namespace MyApp.DAL.InfraStructure.IRepository;

public interface IAccessAllRepo
{
    IUserRepo UserRepo { get; }
    ITokenRepo TokenRepo { get; }
    Task SaveAsync();
}