using ExamenDesarrollador.Data.Repositorys;
using ExamenDesarrollador.Data.Repositorys.Clients.Products;
using ExamenDesarrollador.Entitys.Comuns;
using ExamenDesarrollador.Entitys.Products.Interfaces;
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

        }
    }
}
