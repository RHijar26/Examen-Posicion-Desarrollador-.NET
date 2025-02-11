using ExamenDesarrollador.Entitys.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Products
{
    [Table(nameof(ProductShop))]
    public class ProductShop
    {                
        public int ProductId { get; set; }
        public int ShopId { get; set; }
        public DateTime DateRegister { get; set; }


        #region  ForeingKeys

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; }

        #endregion

    }
}
