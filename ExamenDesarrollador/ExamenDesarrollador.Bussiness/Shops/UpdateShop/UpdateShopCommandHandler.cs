using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using ExamenDesarrollador.Entitys.Shops;
using ExamenDesarrollador.Entitys.Shops.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Shops.UpdateShop
{
    public class UpdateShopCommand : CommandBase<Shop>
    {
        public Shop Shop { get; set; }

        public UpdateShopCommand(Shop shop)
        {
            Shop = shop;
        }
    }
    public class UpdateShopCommandHandler : ICommandHandler<UpdateShopCommand, Shop>
    {
        private readonly IRepositoryShop repositoryShop;
        public IUnitOfWork UnitOfWork {  get; set; }

        public UpdateShopCommandHandler(IRepositoryShop repositoryShop, IUnitOfWork unitOfWork)
        {
            this.repositoryShop = repositoryShop;
            UnitOfWork = unitOfWork;
        }

        public async Task<Shop> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            if (request.Shop.Id == 0)
            {
                throw new Exception("El ID del Cliente no Puede ser 0");
            }

            if (string.IsNullOrEmpty(request.Shop.Sucursal))
            {
                throw new Exception("El Nombre de la Tienda es Requerido");
            }

            if (string.IsNullOrEmpty(request.Shop.Address))
            {
                throw new Exception("La Dirección de la Tienda es Requerida");
            }

            var shopBD = await repositoryShop.GetById(request.Shop.Id);
            shopBD = request.Shop;

            await repositoryShop.Update(shopBD, shopBD.Id);

            await UnitOfWork.CommitAsync();

            return shopBD;
        }
    }
}
