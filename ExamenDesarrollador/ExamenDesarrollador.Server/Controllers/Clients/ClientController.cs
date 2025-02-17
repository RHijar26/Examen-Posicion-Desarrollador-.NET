using ExamenDesarrollador.Bussiness.Clients.InsertClient;
using ExamenDesarrollador.Bussiness.Products.GetProducts;
using ExamenDesarrollador.Bussiness.Products.InsertProduct;
using ExamenDesarrollador.Bussiness.Products.RemoveProduct;
using ExamenDesarrollador.Bussiness.Products.UpdateProduct;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Products;
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


        [HttpPost]
        public async Task<IActionResult> InsertProduct(Client client)
        {
            var result = await _mediator.Send(new InsertClientCommand(client));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductss()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }


    }
}
