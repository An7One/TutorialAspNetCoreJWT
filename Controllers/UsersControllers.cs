using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TutorialCoreJWT.Services;
using TutorialCoreJWT.Models;

namespace TutorialCoreJWT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = userService.Authenticate(model.Email, model.Password);

            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }
    }
}
