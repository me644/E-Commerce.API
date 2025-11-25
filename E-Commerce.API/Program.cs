using AutoMapper;
using Domain.Contracts;
using Domain.Entites.IdentityModule;
using E_Commerce.API.Factories;
using E_Commerce.API.MIddleWares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.TypeMapping;
using Presentation.Data;
using Presistance.Data;
using Presistance.Repositories;
using Service.Abstraction.Contracts;
using Service.Implementation;
using Service.MappingServices;
using StackExchange.Redis;
using System;
using System.Data;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ----------------------
            // 1️⃣ Add DbContext
            // ----------------------
            builder.Services.AddDbContext<StoreDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IDataSeed, DataSeeding>();


            builder.Services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                return ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")!);
            });

            builder.Services.AddDbContext<IdentityStoreDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection")));
            // ----------------------
            // 2️⃣ Add UnitOfWork
            // ----------------------
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
          
            builder.Services.AddScoped<IBasketRepository,BasketRepository>();

            // ----------------------
            // 3️⃣ Add AutoMapper
            // ----------------------
            builder.Services.AddAutoMapper(m => m.AddProfile<ProductProfile>()); // أو typeof(MappingProfile)
            builder.Services.AddAutoMapper(m => m.AddProfile<OrderProfile>());
            builder.Services.AddAutoMapper(m => m.AddProfile<BasketProfile>());
            builder.Services.AddScoped<ISerivceMnager, ServiceManger>();

           
                builder.Services.AddIdentity<User,IdentityRole>(option=>option.Password.RequireDigit=true)
                
 
                    .AddEntityFrameworkStores<IdentityStoreDbContext>();

            builder.Services.AddTransient<PictureUrlResolver>();    
            // ----------------------
            // 4️⃣ Add Controllers
            // ----------------------
            builder.Services.AddControllers();

            // ----------------------
            // 5️⃣ Add Swagger
            // ----------------------
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //validations
            builder.Services.Configure<ApiBehaviorOptions>(options =>

            options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidationErrorResponse
            );


            // ----------------------
            // 6️⃣ Build the app
            // ----------------------

            
            var app = builder.Build();
            var oo=app.Services.CreateScope();
            var objectIdenSeeding = oo.ServiceProvider.GetRequiredService<IDataSeed>();
            objectIdenSeeding.DataSeedAsync();

            objectIdenSeeding.SeedIDentityAsync();
        
            // ----------------------
            // 7️⃣ Configure Middleware
            // ----------------------
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalHandllingMiddleWare>();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            // ----------------------
            // 8️⃣ Run the app
            // ----------------------
            app.Run();
        }
    }
}