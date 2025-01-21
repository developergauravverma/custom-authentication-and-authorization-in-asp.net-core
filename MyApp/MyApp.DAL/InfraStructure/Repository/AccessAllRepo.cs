using MyApp.DAL.Connection;
using MyApp.DAL.InfraStructure.IRepository;

namespace MyApp.DAL.InfraStructure.Repository;

public class AccessAllRepo : IAccessAllRepo
{
    public IUserRepo UserRepo { get; private set; }
    private readonly AppDbConnection repo;
    public ITokenRepo TokenRepo { get; private set; }

    public AccessAllRepo(AppDbConnection context)
    {
        this.repo = context;
        UserRepo = new UserRepo(repo);
        TokenRepo = new TokenRepo(repo);
    }
    public async Task SaveAsync()
    {
        await repo.SaveChangesAsync();
    }
}