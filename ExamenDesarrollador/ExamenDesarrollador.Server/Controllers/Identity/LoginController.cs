using ExamenDesarrollador.Bussiness.Identity.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace ExamenDesarrollador.Server.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomControllerBase
    {
        public LoginController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }


        [HttpPost]
        public async Task<IActionResult> Login(string user, string passWord)
        {
            var result = await _mediator.Send(new LoginCommand(user,passWord));

            return Ok(new { result });
        }
    }
}
