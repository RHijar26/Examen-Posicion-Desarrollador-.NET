using ExamenDesarrollador.Data.Repositorys;
using ExamenDesarrollador.Data.Repositorys.Clients;
using ExamenDesarrollador.Data.Repositorys.Products;
using ExamenDesarrollador.Data.Repositorys.Shops;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.Comuns;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.Shops.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data
{
    public static class DependecyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryProducts, RepositoryProducts>();
            services.AddScoped<IRepositoryClient, RepositoryClient>();
            services.AddScoped<IRepositoryShop, RepositoryShop>();
            services.AddScoped<IRepositoryClientBuy, RepositoryClientBuy>();

        }
    }
}
