using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.UserLogin
{
    public interface IUserLoginRepository
    {
        bool VerifyUserLogin(User user);

        bool Login(User user);
    }
}
