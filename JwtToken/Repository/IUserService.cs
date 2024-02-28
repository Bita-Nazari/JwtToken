using JwtToken.Model;
using Microsoft.Win32;

namespace JwtToken.Repository
{
    public interface IUserService
    {
        Task<User> RegisterNew(RegisterModel model);
        Task<LogInModel> Login(LogInModel model);
        string GenerateJwtToken(string user);
    }

}
