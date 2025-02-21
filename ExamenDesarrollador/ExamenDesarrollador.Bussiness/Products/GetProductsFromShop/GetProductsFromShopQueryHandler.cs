using ExamenDesarrollador.Bussiness.Configuration.Queries;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Products.GetProductsFromShop
{
    public class GetProductFromShopQuery : IQuery<List<Product>>
    {
        public int Sucursal { get; set; }

        public GetProductFromShopQuery(int sucursal)
        {
            Sucursal = sucursal;
        }
    }
    public class GetProductsFromShopQueryHandler : IQueryHandler<GetProductFromShopQuery, List<Product>>
    {
        private readonly IRepositoryProductShop repositoryProductShop;

        public GetProductsFromShopQueryHandler(IRepositoryProductShop repositoryProductShop)
        {
            this.repositoryProductShop = repositoryProductShop;
        }

        public async Task<List<Product>> Handle(GetProductFromShopQuery request, CancellationToken cancellationToken)
        {
            var result = await repositoryProductShop.GetProductFromShop(request.Sucursal);

            return result;
        }
    }
}
