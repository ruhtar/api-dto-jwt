using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "teste" && password == "1234")
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
