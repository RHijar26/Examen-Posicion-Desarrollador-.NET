using ExamenDesarrollador.Bussiness.Configuration.Queries;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Products.GetProducts
{
    public class GetProducts : IQuery<List<Product>>
    {

    }

    public class GetProductsQueryHandler : IQueryHandler<GetProducts, List<Product>>
    {
        private readonly IRepositoryProducts repositoryProducts;

        public GetProductsQueryHandler(IRepositoryProducts repositoryProducts)
        {
            this.repositoryProducts = repositoryProducts;
        }

        public async Task<List<Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = await repositoryProducts.GetProducts();

            return products;
        }
    }
}
