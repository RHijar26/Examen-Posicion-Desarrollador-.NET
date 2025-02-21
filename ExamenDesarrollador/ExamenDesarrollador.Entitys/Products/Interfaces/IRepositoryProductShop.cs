using ExamenDesarrollador.Entitys.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Products.Interfaces
{
    public interface IRepositoryProductShop : IRepositoryGeneric<ProductShop>
    {
        Task<List<Product>> GetProductFromShop(int sucursalId);
    }
}
