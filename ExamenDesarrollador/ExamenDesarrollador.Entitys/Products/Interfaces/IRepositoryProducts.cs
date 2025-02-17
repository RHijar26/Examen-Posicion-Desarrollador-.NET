using ExamenDesarrollador.Entitys.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Products.Interfaces
{
    public interface IRepositoryProducts : IRepositoryGeneric<Product>
    {
        Task<Product> SearchProductFromCode(string code);
        Task<Product> SearchProductFromName(string name);

        Task<List<Product>> GetProducts(); 

    }
}
