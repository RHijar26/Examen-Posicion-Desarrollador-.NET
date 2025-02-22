using ExamenDesarrollador.Bussiness.Products;
using ExamenDesarrollador.Entitys.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Shops
{
    public class ShopDTO
    {
        public int Id { get; set; }        
        public string Sucursal { get; set; }        
        public string Address { get; set; }

        public ICollection<ProductShopDTO> ProductShop { get; set; }
    }
}
