using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "teste" && password == "1234")
            {
                var token = TokenService.GenerateToken(new Models.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
