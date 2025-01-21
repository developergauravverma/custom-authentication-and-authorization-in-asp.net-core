using MyApp.Models.Models;

namespace MyApp.DAL.InfraStructure.IRepository;

public interface IUserRepo : IRepository<User>
{
    public Task UpdateUserAsync(User user);
}