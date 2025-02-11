using ExamenDesarrollador.Entitys.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Clients
{
    //Relación -> cliente – articulo 
    //Interpretandolo como articulos que el cliente Compra/Obtiene

    public class ClientBuy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set;}
        public int Amount { get; set; }        
        public DateTime Date { get; set; }


        #region ForeingKeys

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }         

        #endregion
    }
}
