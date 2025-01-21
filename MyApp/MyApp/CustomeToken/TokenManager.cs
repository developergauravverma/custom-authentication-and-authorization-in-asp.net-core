using MyApp.DAL.InfraStructure.IRepository;
using MyApp.Models.Models;

namespace MyApp.CustomeToken;

public class TokenManager(IAccessAllRepo repo) : ITokenManager
{
    public async Task<Token> NewToken()
    {
        var token = new Token()
        {
            Value = Guid.NewGuid().ToString(),
            ExpireDate = DateTime.Now.AddMinutes(1),
        };
        await repo.TokenRepo.SaveEntity(token);
        await repo.SaveAsync();
        return token;
    }

    public async Task<bool> VerifyToken(string token)
    {
        Token? valid = await repo.TokenRepo.GetDataById(x => x.Value!.Equals(token) && x.ExpireDate > DateTime.Now);
        if (valid is not null) return true;
        return false;
    }
}