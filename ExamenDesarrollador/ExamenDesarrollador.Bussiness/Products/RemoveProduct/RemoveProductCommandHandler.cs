using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Products.RemoveProduct
{
    public class RemoveProductCommand : CommandBase<bool>
    {
        public int ProductId { get; set; }

        public RemoveProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
    public class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand, bool>
    {
        private readonly IRepositoryProducts repositoryProducts;
        public IUnitOfWork UnitOfWork { get; set; }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {

            if (request.ProductId == 0)
            {
                throw new Exception("El ID del Producto no Puede ser 0");
            }

            var productBD = await repositoryProducts.GetById(request.ProductId);
            if(productBD == null)
            {
                throw new Exception("No se ha Encontrado el producto");
            }

            await repositoryProducts.Delete(productBD);

            await UnitOfWork.CommitAsync();

            return true;


        }
    }
}
