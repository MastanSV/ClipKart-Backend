using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.UserLogin
{
    public interface IUserSignupService
    {
        bool SignupUser(SignupUser user);
    }
}
