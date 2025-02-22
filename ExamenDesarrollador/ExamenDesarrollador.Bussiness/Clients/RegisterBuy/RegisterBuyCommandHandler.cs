using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenDesarrollador.Bussiness.Clients.RegisterBuy
{
    public class RegisterBuyCommand : CommandBase<bool>
    {
        public List<CartDTO> CartDTO { get; set; }
        public int ClientId { get; set; }

        public RegisterBuyCommand(List<CartDTO> cartDTO, int clientId)
        {
            CartDTO = cartDTO;
            ClientId = clientId;
        }
    }
    public class RegisterBuyCommandHandler : ICommandHandler<RegisterBuyCommand, bool>
    {
        private readonly IRepositoryClientBuy repositoryClientBuy;
        private readonly IRepositoryProducts repositoryProducts;
        public IUnitOfWork UnitOfWork { get;set; }

        public RegisterBuyCommandHandler(IRepositoryClientBuy repositoryClientBuy, IRepositoryProducts repositoryProducts, IUnitOfWork unitOfWork)
        {
            this.repositoryClientBuy = repositoryClientBuy;
            this.repositoryProducts = repositoryProducts;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RegisterBuyCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.CartDTO)
            {
                var product = await repositoryProducts.GetById(item.Product.Id);

                if(product.Stock < item.Cantidad)
                {
                    throw new Exception($"No hay Stock suficiente de {product.Name}");
                }

                if(product.Price == 0)
                {
                    throw new Exception("No se Pueden Comprar Productos con Precio 0");
                }

                var clientBuy = new ClientBuy
                {
                    ClientId = request.ClientId,
                    ProductId = product.Id,
                    Amount = item.Cantidad,
                    Date = DateTime.Now,
                };

                product.Stock -= item.Cantidad;

                await repositoryClientBuy.Insert(clientBuy);
                await repositoryProducts.Update(product, product.Id);
            }


            await UnitOfWork.CommitAsync();

            return true;            
        }
    }
}
