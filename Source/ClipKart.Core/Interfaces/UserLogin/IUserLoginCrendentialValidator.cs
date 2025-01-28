using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.UserLogin
{
    public interface IUserLoginCrendentialValidator
    {
        bool Validate(User user);
    }
}
