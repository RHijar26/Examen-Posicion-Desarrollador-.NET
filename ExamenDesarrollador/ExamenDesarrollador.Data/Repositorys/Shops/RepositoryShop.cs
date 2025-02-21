using ExamenDesarrollador.Data.Context;
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
    }
}
