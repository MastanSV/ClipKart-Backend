
using ClipKart.Core.Constants;
using ClipKart.Core.Interfaces.Common;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using ClipKart.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private IUserLoginCrendentialValidator _credentialValidator;
        private IUserLoginService _userLoginService;
        private IJWTTokenGenerator _jwtTokenGenerator;

        public UserLoginController(IUserLoginCrendentialValidator credentialValidator, IUserLoginService userLoginService, IJWTTokenGenerator jwtTokenGenerator)
        {
            _credentialValidator = credentialValidator;
            _userLoginService = userLoginService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User user)
        {
            bool result = _credentialValidator.Validate(user);
            if ((result))
            {
                var token = _jwtTokenGenerator.Generate("1", UserRoles.Admin);
                return Ok(new {Token = token});
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
