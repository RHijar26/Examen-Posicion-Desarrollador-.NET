﻿using ExamenDesarrollador.Bussiness.Products.GetProducts;
using ExamenDesarrollador.Bussiness.Products.GetProductsFromShop;
using ExamenDesarrollador.Bussiness.Products.InsertProduct;
using ExamenDesarrollador.Bussiness.Products.RemoveProduct;
using ExamenDesarrollador.Bussiness.Products.UpdateProduct;
using ExamenDesarrollador.Entitys.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExamenDesarrollador.Server.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        public ProductController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            var result = await _mediator.Send(new InsertProductCommand(product));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductss()
        {
            var result = await _mediator.Send(new GetProducts());

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _mediator.Send(new UpdateProductCommand(product));

            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            var result = await _mediator.Send(new RemoveProductCommand(productId));

            return Ok(result);
        }

        [HttpGet("GetProductsFromShop")]
        public async Task<IActionResult> GetProductsFromShop(int sucursal)
        {
            var result = await _mediator.Send(new GetProductFromShopQuery(sucursal));

            return Ok(result);
        }
    }
    
}
