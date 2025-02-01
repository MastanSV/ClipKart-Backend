using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.UserLogin
{
    public interface IUserLoginService
    {
        bool VerifyLogin(User user);
    }
}
