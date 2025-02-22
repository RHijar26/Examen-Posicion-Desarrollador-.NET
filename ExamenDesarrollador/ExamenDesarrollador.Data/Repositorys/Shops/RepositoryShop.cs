using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Shops;
using ExamenDesarrollador.Entitys.Shops.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Repositorys.Shops
{
    public class RepositoryShop : RepositoryGeneric<Shop>, IRepositoryShop
    {
        public RepositoryShop(ContextDBO context) : base(context)
        {
        }

        public async Task<List<Shop>> GetShops()
        {
            var shops = await _context.Shop
                .ToListAsync();

            return shops;
        }

        public async Task UpdateProductFromShop(List<ProductShop> productShop, int shopId)
        {
            var productShopBD = await _context.ProductShop.Where(ps => ps.ShopId == shopId).ToListAsync();

            var toInsert = productShop.Where(ps => !productShopBD.Any(psBD => psBD.ProductId == ps.ProductId)).ToList();

            foreach (var item in toInsert)
            {
                item.DateRegister = DateTime.Now;

                await _context.Set<ProductShop>().AddAsync(item);
            }

            var toDelete = productShopBD.Where(psBD => !productShop.Any(ps => psBD.ProductId == ps.ProductId)).ToList();

            if (toDelete.Any())
            {
                _context.Set<ProductShop>().RemoveRange(toDelete);
            }

        }
    }
}
