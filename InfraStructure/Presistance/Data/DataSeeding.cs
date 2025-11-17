
using Domain.Contracts;
using Domain.Entites.IdentityModule;
using Domain.Entites.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance.Data
{
    public class DataSeeding(StoreDbContext _store,RoleManager<IdentityRole>_roleManager,UserManager<User>_userManager) : IDataSeed
    {
        public async Task DataSeedAsync()
        {


            try
            {

                if ((await _store.Database.GetPendingMigrationsAsync()).Any())
                {

                    _store.Database.Migrate();
                    
                }

                if (!_store.ProductBrands.Any())
                {

                    var productBrandData =  await File.ReadAllTextAsync("..\\InfraStructure\\Presistance\\Data\\DataSeed\\brands.json");
                    var ProductBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);

                    if (ProductBrands is not null && ProductBrands.Any())
                    {


                        _store.AddRange(ProductBrands);

                           }
                }
                if (!_store.ProductTypes.Any())
                {

                    var productTypeData = File.ReadAllText("D:\\dotnet\\Course\\API\\Session1\\E-Commerce.API\\InfraStructure\\Presistance\\Data\\DataSeed\\types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                    if (productTypes is not null && productTypes.Any())
                    {
                        _store.AddRange(productTypes);
                    }

                }
                if (!_store.Products.Any())
                {

                    var productData = File.ReadAllText("..\\InfraStructure\\Presistance\\Data\\DataSeed\\products.json");
                    var products = JsonSerializer.Deserialize<List<ProductType>>(productData);
                    if (products is not null && products.Any())
                    {
                        _store.AddRange(products);
                    }

                }
                _store.SaveChanges();

            }
            catch(Exception E) { }

        }

        public async Task SeedIDentityAsync()
        {
            try
            {
                if ( ! _roleManager.Roles.Any())
                {
                  await  _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });


                    await _roleManager.CreateAsync(new IdentityRole() { Name = "SuperAdmin" });

                }
                if (!_userManager.Users.Any())
                {


                    var admin = new User()
                    {
                        DisplayName = "Admin",
                        UserName = "Admin", 
                        Email = "mk05@gmail.com",
                        PhoneNumber = "0122452"
                    };
                    var Superadmin = new User()
                    {
                        DisplayName = "SuoerAdmin",
                        UserName = "SuperAdmin",
                        Email = "Supermk05@gmail.com",
                        PhoneNumber = "0102222"

                    };

                    //add_User
                    await _userManager.CreateAsync(admin,password:"P@ssw0rd");


                    await _userManager.CreateAsync(Superadmin, "P@ssw0rd");


                    //Assign ROlE=>User
                    await _userManager.AddToRoleAsync(admin, "Admin");
                    await _userManager.AddToRoleAsync(Superadmin, "SuperAdmin");
                }


            }

            catch (Exception) { throw; }
        }
    }
}
