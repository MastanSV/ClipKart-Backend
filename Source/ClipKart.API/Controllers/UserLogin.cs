
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using ClipKart.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLogin : ControllerBase
    {
        private IUserLoginCrendentialValidator _credentialValidator;
        private IUserLoginService _userLoginService;

        public UserLogin(IUserLoginCrendentialValidator credentialValidator, IUserLoginService userLoginService)
        {
            _credentialValidator = credentialValidator;
            _userLoginService = userLoginService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User user)
        {
            _userLoginService.VerifyLogin(user);
            bool result = _credentialValidator.Validate(user);
            if ((result))
            {
                return Ok("User Login Successful.");
            }

            return BadRequest("User Login Failed.");
        }

        [HttpPost]
        [Route("VerifyLogin")]
        public bool VerifyLogin(User user)
        {
            _userLoginService.VerifyLogin(user);
            return true;
        }
    }
}
