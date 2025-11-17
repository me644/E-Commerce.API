using Domain.Entites.Product;
using Microsoft.EntityFrameworkCore;
using Presistance.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Data
{
    public class StoreDbContext:DbContext
    {


        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

         //assembly for the stratUp   modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         

            ///made embty class to know him read from what
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefernce).Assembly);
        }


        public DbSet<Product> Products {  get; set; }

        public DbSet<ProductType> ProductTypes {  get; set; }


        public DbSet<ProductBrand> ProductBrands { get; set; }


    }
}
