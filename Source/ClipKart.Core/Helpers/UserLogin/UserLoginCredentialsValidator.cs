using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;

namespace ClipKart.Core.Helpers.UserLogin
{
    public class UserLoginCredentialsValidator : IUserLoginCrendentialValidator
    {
        public bool Validate(User user)
        {
            if (!IsUserCredentialsContainsNull(user))
            {
                return false;
            }

            if (IsUserCredentialsValid(user))
            {
                return true;
            }

            return false;
        }

        private bool IsUserCredentialsValid(User user)
        {
            if (user.UserName == "mastanvali157@gmail.com" && user.Password == "abcdefghi")
            {
                return true;
            }

            return false;
        }

        private bool IsUserCredentialsContainsNull(User user)
        {
            if (user.UserName == null || user.Password == null)
            {
                return false;
            }

            return true;
        }


    }

}
