using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Products.UpdateProduct
{
    public class UpdateProductCommand : CommandBase<Product>
    {
        public Product Product { get; set; }

        public UpdateProductCommand(Product product)
        {
            Product = product;
        }
    }
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Product>
    {
        private readonly IRepositoryProducts repositoryProducts;
        public IUnitOfWork UnitOfWork { get; set; }

        public UpdateProductCommandHandler(IRepositoryProducts repositoryProducts, IUnitOfWork unitOfWork)
        {
            this.repositoryProducts = repositoryProducts;
            UnitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Product.Id == 0)
            {
                throw new Exception("El ID del Producto no Puede ser 0");
            }

            var productBD = await repositoryProducts.GetById(request.Product.Id);

            productBD = request.Product;

            await repositoryProducts.Update(productBD, productBD.Id);

            await UnitOfWork.CommitAsync();

            return productBD;            
        }
    }
}
