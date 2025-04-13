using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSignupController : ControllerBase
    {
        private IUserSignupService _userSignupService;

        public UserSignupController(IUserSignupService userSignupService)
        {
            _userSignupService = userSignupService;
        }

        [HttpPost("Signup")]
        public IActionResult Signup([FromBody]SignupUser signUpUser)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest("Bad Request sent!.");
            }
            if (_userSignupService.SignupUser(signUpUser))
            {
                return Ok(new { message = "user signedup successfully.!" });
            }

            return BadRequest("Error occured while registering the user!.");
        }
    }
}
