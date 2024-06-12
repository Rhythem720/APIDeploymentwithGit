using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurfBooking.ApplicationLayer.Services;
using TurfBooking.Domain.Entities;

namespace TurfBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet("Login User")]
        public IActionResult LoginUser(string useremail, string password)
        {
            if((useremail == null || password == null)) 
                return BadRequest($"username or password is null");
            else
                return Ok(_loginService.LoginUser(useremail, password));   
        }

        [HttpPost("Register New User")]
        public IActionResult RegisterUser(User user)
        {
            if(user == null || !_loginService.RegisterUser(user))
            {
                return BadRequest($"Registration of  {user.UserName} is failed");
            }
            else
            {
                return Ok($"User registered with {user.UserEmail} successfully");
            }
               
              
        }
    }
}
