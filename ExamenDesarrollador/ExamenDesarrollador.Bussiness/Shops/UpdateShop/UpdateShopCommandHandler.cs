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

namespace ExamenDesarrollador.Bussiness.Shops.UpdateShop
{
    public class UpdateShopCommand : CommandBase<Shop>
    {
        public ShopDTO ShopDTO { get; set; }

        public UpdateShopCommand(ShopDTO shop)
        {
            ShopDTO = shop;
        }
    }
    public class UpdateShopCommandHandler : ICommandHandler<UpdateShopCommand, Shop>
    {
        private readonly IRepositoryShop repositoryShop;
        private readonly IMapper mapper;
        public IUnitOfWork UnitOfWork {  get; set; }
        public UpdateShopCommandHandler(IRepositoryShop repositoryShop, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repositoryShop = repositoryShop;
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Shop> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = mapper.Map<Shop>(request.ShopDTO);

            if (shop.Id == 0)
            {
                throw new Exception("El ID del Cliente no Puede ser 0");
            }

            if (string.IsNullOrEmpty(shop.Sucursal))
            {
                throw new Exception("El Nombre de la Tienda es Requerido");
            }

            if (string.IsNullOrEmpty(shop.Address))
            {
                throw new Exception("La Dirección de la Tienda es Requerida");
            }            

            await repositoryShop.Update(shop, shop.Id);


            await repositoryShop.UpdateProductFromShop(shop.ProductShop.ToList(), shop.Id);

            await UnitOfWork.CommitAsync();

            return shop;
        }
    }
}
