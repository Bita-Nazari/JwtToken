using JwtToken.Model;
using JwtToken.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost ,Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "register failed" });
            }
            var resault = await _userService.RegisterNew(model);
            return Ok(resault);
        }
        [HttpPost, Route("LogIn")]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "register failed" });
            }
            var resault = await _userService.Login(model);
            return Ok(resault);
        }
    }
}
