using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Products;
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
        public IUnitOfWork UnitOfWork { get; set; }

        public Task<Product> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
