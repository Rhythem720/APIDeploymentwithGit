using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurfBooking.ApplicationLayer.Services;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        [Authorize(Roles = "Admin")]
        public class UserController : ControllerBase
        {
            private readonly UserService _userService;

            public UserController(UserService userService)
            {
                _userService = userService;
            }

            //[HttpPost("AddNewUser")]
            //public IActionResult AddNewUser(User user)
            //{
            //    if (_userService.AddUser(user))
            //    {
            //        return Ok("User added successfully");
            //    }
            //    else
            //        return Ok("User not registered");

            //}

            [HttpGet("Get Users")]


            public IActionResult GetAllUser()
            {
                return Ok(_userService.GetAllUsers());
            }

            //[HttpGet("LoginUser")]
            //public IActionResult LoginUser(string useremail, string password)
            //{
            //    return Ok(_userService.LoginUser(useremail, password));  
            //}

            [HttpDelete("UnRegister User")]
            public IActionResult UnRegisterUser(int id)
            {
                if (_userService.UnRegisterUser(id) != null)
                {
                    return Ok("User UnRegistered Or Deleted successfully");
                }
                else
                {
                    return Ok("User deletion failed");
                }
            }
            [HttpPatch("Update User")]
            public IActionResult UpdateUser(int id, User user)
            {
                if (id == user.UserId && user != null)
                {
                    if (_userService.UpdateUserDetails(user))
                        return Ok($"{user.UserName} updated successfully");
                    else return BadRequest($"{user.UserName} failed to update the user");
                }
                else
                    return Ok($"{user.UserName} failed to update the user");
            }
        }
    
}
