using Domain.Entites.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data  
{
    public class IdentityStoreDbContext
     : IdentityDbContext<User, IdentityRole, string>
    {
        public IdentityStoreDbContext(DbContextOptions<IdentityStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<User>().ToTable("Users");
        }
    }
}
