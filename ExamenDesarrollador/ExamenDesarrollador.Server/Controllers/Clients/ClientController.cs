using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenDesarrollador.Server.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CustomControllerBase
    {
        public ClientController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }




    }
}
