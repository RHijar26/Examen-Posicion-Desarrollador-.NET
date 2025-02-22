using ExamenDesarrollador.Entitys.Shops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Products
{
    [Table(nameof(ProductShop))]
    [PrimaryKey(nameof(ProductId),nameof(ShopId))]
    public class ProductShop
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Key]
        [Required]
        public int ShopId { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DateRegister { get; set; }


        #region  ForeingKeys

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(ShopId))]
        [JsonIgnore]
        public Shop Shop { get; set; }

        #endregion

    }
}
