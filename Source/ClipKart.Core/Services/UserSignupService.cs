using ClipKart.Core.Interfaces.UserLogin;

namespace ClipKart.Core.Services
{
    public class UserSignupService : IUserSignupService
    {
        private IUserSignupRepository _userSignupRepository;

        public UserSignupService(IUserSignupRepository userSignupRepository)
        {
            _userSignupRepository = userSignupRepository;
        }
    }
}
