using ExamenDesarrollador.Bussiness.Clients.GetClients;
using ExamenDesarrollador.Bussiness.Clients.InsertClient;
using ExamenDesarrollador.Bussiness.Clients.RegisterBuy;
using ExamenDesarrollador.Bussiness.Clients.RemoveClient;
using ExamenDesarrollador.Bussiness.Clients.UpdateClient;
using ExamenDesarrollador.Bussiness.Products.GetProducts;
using ExamenDesarrollador.Bussiness.Products.InsertProduct;
using ExamenDesarrollador.Bussiness.Products.RemoveProduct;
using ExamenDesarrollador.Bussiness.Products.UpdateProduct;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ExamenDesarrollador.Server.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CustomControllerBase
    {
        public ClientController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }


        [HttpPost]
        public async Task<IActionResult> InsertClient(Client client)
        {
            var result = await _mediator.Send(new InsertClientCommand(client));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var result = await _mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            var result = await _mediator.Send(new UpdateClientCommand(client));

            return Ok(result);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> RemoveProduct(int clientId)
        {
            var result = await _mediator.Send(new RemoveClientCommand(clientId));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterBuy(List<CartDTO> cartDTO)
        {
            var result = await _mediator.Send(new RegisterBuyCommand(cartDTO, ClientId));
            return Ok(result);
        }

    }
}
