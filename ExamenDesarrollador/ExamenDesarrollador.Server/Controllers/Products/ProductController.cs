﻿using ExamenDesarrollador.Bussiness.Products.InsertProduct;
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

        [HttpPost()]
        public async Task<IActionResult> InsertProduct(Product product)
        {

            var result = await _mediator.Send(new InsertProductCommand(product));

            return Ok(result);


        }
    }
}
