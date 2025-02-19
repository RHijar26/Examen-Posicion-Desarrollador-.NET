using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenDesarrollador.Server.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomControllerBase
    {
        public LoginController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password")
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
