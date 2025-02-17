using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenDesarrollador.Bussiness.Products.InsertProduct
{
    public class InsertProductCommand : CommandBase<Product>
    {
        public Product Product { get; set; }

        public InsertProductCommand(Product product)
        {
            Product = product;
        }
    }

    public class InsertProductCommandHandler : ICommandHandler<InsertProductCommand, Product>
    {
        private readonly IRepositoryProducts repositoryProducts;
        
        public IUnitOfWork UnitOfWork { get; set; }

        public InsertProductCommandHandler(IRepositoryProducts repositoryProducts, IUnitOfWork unitOfWork)
        {
            this.repositoryProducts = repositoryProducts;
            UnitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            //Valide product unique
            var productCodeValidation = await repositoryProducts.SearchProductFromCode(request.Product.Code);
            if(productCodeValidation != null)
            {
                throw new Exception("El Código del Producto ya Existe");
            }

            var productNameValidation = await repositoryProducts.SearchProductFromName(request.Product.Name);
            if(productNameValidation != null)
            {
                throw new Exception("El Nombre del Producto ya Existe");
            }


            await repositoryProducts.Insert(request.Product);

            await UnitOfWork.CommitAsync();

            return request.Product;            
        }
    }
}
