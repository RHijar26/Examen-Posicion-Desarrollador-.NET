using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Repositorys.Clients.Products
{
    public class RepositoryProducts : RepositoryGeneric<Product>, IRepositoryProducts
    {
        public RepositoryProducts(ContextDBO context) : base(context)
        {
        }

        public async Task<List<Product>> GetProducts()
        {
            var lstProducts = await _context.Product.ToListAsync();

            return lstProducts;
        }

        public async Task<Product> SearchProductFromCode(string code)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Code == code);

            return product;
        }

        public async Task<Product> SearchProductFromName(string name)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Code == name);

            return product;
        }
    }
}
