using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;

namespace ClipKart.Core.Services
{
    public class UserSignupService : IUserSignupService
    {
        private IUserSignupRepository _userSignupRepository;

        public UserSignupService(IUserSignupRepository userSignupRepository)
        {
            _userSignupRepository = userSignupRepository;
        }

        public bool SignupUser(SignupUser user)
        {
            _userSignupRepository.SignupUser(user);
            return true;
        }
    }
}
