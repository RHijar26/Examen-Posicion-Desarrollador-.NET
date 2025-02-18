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
using System.Windows.Input;

namespace ExamenDesarrollador.Bussiness.Shops.InsertShop
{
    public class InsertShopCommand : CommandBase<Shop>
    {
        public Shop Shop { get; set; }
        public InsertShopCommand(Shop shop)
        {
            Shop = shop;
        }
    }
    public class InsertShopCommandHandler : ICommandHandler<InsertShopCommand, Shop>
    {
        private readonly IRepositoryShop repositoryShop;
        public IUnitOfWork UnitOfWork {  get; set; }

        public InsertShopCommandHandler(IRepositoryShop repositoryShop, IUnitOfWork unitOfWork)
        {
            this.repositoryShop = repositoryShop;
            UnitOfWork = unitOfWork;
        }

        public async Task<Shop> Handle(InsertShopCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.Shop.Sucursal))
            {
                throw new Exception("El Nombre de la Tienda es Requerido");
            }

            if (string.IsNullOrEmpty(request.Shop.Address))
            {
                throw new Exception("La Dirección de la Tienda es Requerida");
            }


            await repositoryShop.Insert(request.Shop);

            await UnitOfWork.CommitAsync();

            return request.Shop;            
        }
    }
}
