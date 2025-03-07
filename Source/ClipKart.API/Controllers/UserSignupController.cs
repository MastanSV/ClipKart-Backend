using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [Controller]
    public class UserSignupController : ControllerBase
    {
        private IUserSignupService _userSignupService;

        public UserSignupController(IUserSignupService userSignupService)
        {
            _userSignupService = userSignupService;
        }

        [HttpPost]
        public IActionResult Signup([FromBody]SignupUser signUpUser)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest("Bad Request sent!.");
            }

            _
            return Ok();
        }
    }
}
