using ExamenDesarrollador.Entitys.Comuns;
using ExamenDesarrollador.Entitys.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Shops.Interfaces
{
    public interface IRepositoryShop : IRepositoryGeneric<Shop>
    {
        Task<List<Shop>> GetShops();
        Task UpdateProductFromShop(List<ProductShop> productShop,int shopId);
    }
}
