using AutoMapper;
using ExamenDesarrollador.Bussiness.Products;
using ExamenDesarrollador.Bussiness.Shops;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Shops;

namespace ExamenDesarrollador.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ShopDTO, Shop>();
            CreateMap<ProductShopDTO, ProductShop>();


        }
    }
}
