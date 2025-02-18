using ExamenDesarrollador.Entitys.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Clients.RegisterBuy
{
    public class CartDTO
    {
        public Product Product { get; set; }
        public int Cantidad { get;set; }
    }
}
