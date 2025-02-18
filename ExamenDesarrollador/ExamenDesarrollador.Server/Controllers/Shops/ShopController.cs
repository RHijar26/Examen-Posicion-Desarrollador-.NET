using ExamenDesarrollador.Bussiness.Clients.GetClients;
using ExamenDesarrollador.Bussiness.Clients.InsertClient;
using ExamenDesarrollador.Bussiness.Clients.RemoveClient;
using ExamenDesarrollador.Bussiness.Clients.UpdateClient;
using ExamenDesarrollador.Bussiness.Shops.GetShops;
using ExamenDesarrollador.Bussiness.Shops.InsertShop;
using ExamenDesarrollador.Bussiness.Shops.RemoveShop;
using ExamenDesarrollador.Bussiness.Shops.UpdateShop;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Shops;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenDesarrollador.Server.Controllers.Shops
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : CustomControllerBase
    {
        public ShopController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertShop(Shop shop)
        {
            var result = await _mediator.Send(new InsertShopCommand(shop));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetShops()
        {
            var result = await _mediator.Send(new GetShopsQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShop(Shop shop)
        {
            var result = await _mediator.Send(new UpdateShopCommand(shop));

            return Ok(result);
        }

        [HttpDelete("{shopId}")]
        public async Task<IActionResult> RemoveProduct(int shopId)
        {
            var result = await _mediator.Send(new RemoveShopCommand(shopId));

            return Ok(result);
        }

    }
}
