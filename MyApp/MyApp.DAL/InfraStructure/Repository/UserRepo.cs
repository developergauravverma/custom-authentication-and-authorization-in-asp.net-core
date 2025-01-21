using MyApp.DAL.Connection;
using MyApp.DAL.InfraStructure.IRepository;
using MyApp.Models.Models;

namespace MyApp.DAL.InfraStructure.Repository;

public class UserRepo(AppDbConnection context) : Repository<User>(context), IUserRepo
{
    public async Task UpdateUserAsync(User user)
    {
        await Task.Run(() =>
        {
            context.Update(user);
        });
    }
}