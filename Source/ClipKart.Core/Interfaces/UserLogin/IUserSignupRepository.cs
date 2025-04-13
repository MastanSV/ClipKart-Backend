using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.UserLogin
{
    public interface IUserSignupRepository
    {
        bool SignupUser(SignupUser signupUser);
    }
}
