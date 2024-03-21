using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contexts
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KEKHAR;Database=ProductsTEST;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shopper> Shoppers { get; set; }
    }
}
    