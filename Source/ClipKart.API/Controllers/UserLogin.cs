
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("Login")]
    public class UserLogin : ControllerBase
    {
        private IUserLoginCrendentialValidator _credentialValidator;

        public UserLogin(IUserLoginCrendentialValidator credentialValidator)
        {
            _credentialValidator = credentialValidator;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            bool result = _credentialValidator.Validate(user);
            if ((result))
            {
                return Ok("User Login Successful.");
            }

            return BadRequest("User Login Failed.");
        }


        private bool ValidateCredentials(User user)
        {
            if(user.UserName == "Mastan" && user.Password == "Vali")
            {
                return true;
            }
            return false;
        }
    }
}
