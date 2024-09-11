using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser service;

        public UserController(IUser userService)
        {
            this.service = userService;
        }

        [HttpGet("userForInvoice/{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpGet("login")]
        public async Task<IActionResult> LoginUser([FromQuery] string userid, [FromQuery] string password)
        {
            var user = await service.GetUserByIdAsync(userid);
            if (user != null && user.Password == password)
            {
                return Ok("Login successful");
            }
            return Unauthorized("Invalid user ID or password");
        }



        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            var result = await service.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = result.Userid }, result);
        }
    }
}
