using AutoMapper;
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
        public ShopDTO ShopDTO { get; set; }
        public InsertShopCommand(ShopDTO shop)
        {
            ShopDTO = shop;
        }
    }
    public class InsertShopCommandHandler : ICommandHandler<InsertShopCommand, Shop>
    {
        private readonly IRepositoryShop repositoryShop;
        private readonly IMapper mapper;
        public IUnitOfWork UnitOfWork {  get; set; }

        public InsertShopCommandHandler(IRepositoryShop repositoryShop, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repositoryShop = repositoryShop;
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Shop> Handle(InsertShopCommand request, CancellationToken cancellationToken)
        {

            var shop = mapper.Map<Shop>(request.ShopDTO);

            if (string.IsNullOrEmpty(shop.Sucursal))
            {
                throw new Exception("El Nombre de la Tienda es Requerido");
            }

            if (string.IsNullOrEmpty(shop.Address))
            {
                throw new Exception("La Dirección de la Tienda es Requerida");
            }

            foreach (var item in shop.ProductShop)
            {
                item.DateRegister = DateTime.Now;
            }

            await repositoryShop.Insert(shop);

            await UnitOfWork.CommitAsync();

            return shop;            
        }
    }
}
