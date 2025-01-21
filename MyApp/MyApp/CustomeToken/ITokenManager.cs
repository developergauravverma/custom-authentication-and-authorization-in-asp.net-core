using MyApp.Models.Models;

namespace MyApp.CustomeToken;

public interface ITokenManager
{
    Task<Token> NewToken();
    Task<bool> VerifyToken(string token);
}