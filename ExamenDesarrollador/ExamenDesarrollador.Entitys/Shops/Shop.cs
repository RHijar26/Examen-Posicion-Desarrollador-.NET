using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Shops
{
    [Table(nameof(Shop))]
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Sucursal { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }

    }
}
