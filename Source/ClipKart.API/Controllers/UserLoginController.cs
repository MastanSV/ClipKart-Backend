
using ClipKart.Core.Constants;
using ClipKart.Core.Interfaces.Common;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Validation failed.!");
            }

            bool result = _credentialValidator.Validate(user);
            if ((result))
            {
                var token = _jwtTokenGenerator.Generate("1", UserRoles.Admin);

                Response.Cookies.Append(HelperConstants.JWT, token, new CookieOptions
                { 
                    HttpOnly = true, 
                    Secure = true, 
                    SameSite = SameSiteMode.None, 
                    Expires = DateTime.UtcNow.AddMinutes(20) 
                });

                return Ok(new { message = "Logged in successfully."});
            }

            return BadRequest("User Login Failed.");
        }

        [HttpPost("VerifyLogin")]
        public bool VerifyLogin(User user)
        {
            _userLoginService.VerifyLogin(user);
            return true;
        }
    }
}
