using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Products
{
    [Table(nameof(Product))]
    public class °
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(12, 4)")]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public decimal Stock { get; set; }
    }
}
