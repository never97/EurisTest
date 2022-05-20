using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EurisTest.Models;

namespace EurisTest.Data
{
    public class EurisTestContext : DbContext
    {
        public EurisTestContext(DbContextOptions<EurisTestContext> options)
            : base(options)
        {
        }

        public DbSet<Catalog>? Catalog { get; set; }

        public DbSet<Product>? Product { get; set; }
        //public DbSet<CatalogProduct> CatalogProduct { get; set; }//

        //
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
            modelBuilder.Entity<CatalogProduct>().ToTable("CatalogProduct");
            modelBuilder.Entity<Product>().ToTable("Product");
        }*/
    }
}
