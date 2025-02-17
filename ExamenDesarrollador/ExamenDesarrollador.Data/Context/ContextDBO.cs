using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Products;
using ExamenDesarrollador.Entitys.Shops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Context
{
    public class ContextDBO : DbContext
    {
        public ContextDBO(DbContextOptions<ContextDBO> options) : base(options)
        {
        }


        #region DBSets

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientBuy> ClientBuy { get; set; }

        public virtual DbSet<Shop> Shop { get; set; }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductShop> ProductShop { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
