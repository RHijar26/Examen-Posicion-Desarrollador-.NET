using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using ExamenDesarrollador.Entitys.Shops.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Shops.RemoveShop
{
    public class RemoveShopCommand : CommandBase<bool>
    {
        public int ShopId { get; set; }

        public RemoveShopCommand(int shopId)
        {
            ShopId = shopId;
        }
    }
    public class RemoveShopCommandHandler : ICommandHandler<RemoveShopCommand, bool>
    {
        private readonly IRepositoryShop repositoryShop;
        public IUnitOfWork UnitOfWork {  get; set; }

        public RemoveShopCommandHandler(IRepositoryShop repositoryShop, IUnitOfWork unitOfWork)
        {
            this.repositoryShop = repositoryShop;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveShopCommand request, CancellationToken cancellationToken)
        {
            if (request.ShopId == 0)
            {
                throw new Exception("El ID de la Tienda no Puede ser 0");
            }

            var shopBD = await repositoryShop.GetById(request.ShopId);
            if (shopBD == null)
            {
                throw new Exception("No se ha Encontrado el producto");
            }

            await repositoryShop.Delete(shopBD);

            await UnitOfWork.CommitAsync();

            return true;
        }
    }
}
