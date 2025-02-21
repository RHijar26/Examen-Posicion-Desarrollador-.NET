using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Repositorys.Products
{
    public class RepositoryProductShop : RepositoryGeneric<ProductShop>, IRepositoryProductShop
    {
        public RepositoryProductShop(ContextDBO context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductFromShop(int sucursalId)
        {
            var products = await _context.ProductShop
                .Where(ps => ps.ShopId == sucursalId)
                .Select(ps => ps.Product)
                .ToListAsync();

            return products;
        }
    }
}
