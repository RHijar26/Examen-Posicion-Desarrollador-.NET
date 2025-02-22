using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExamenDesarrollador.Server.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public IMediator _mediator { get; set; }
        public int ClientId { get; set; }

        public CustomControllerBase(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            this._mediator = mediator;

            this.httpContextAccessor = httpContextAccessor;
            var authHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
            {
                var token = authHeader.FirstOrDefault()!.ToString().Substring(7);
                var identity = new ClaimsIdentity(new JwtSecurityTokenHandler().ReadJwtToken(token).Claims, "jwt");
                var IdUsuarioAux = identity.FindFirst("Id").Value;
                ClientId = Convert.ToInt32(IdUsuarioAux);

                var remoteIpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress;                
            }

        }
    }
}
