using AutoMapper;
using Domain.Contracts;
using E_Commerce.API.MIddleWares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Data;
using Presistance.Repositories;
using Service.Abstraction.Contracts;
using Service.Implementation;
using Service.MappingServices;
using System;

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

            // ----------------------
            // 2️⃣ Add UnitOfWork
            // ----------------------
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // ----------------------
            // 3️⃣ Add AutoMapper
            // ----------------------
            builder.Services.AddAutoMapper(m => m.AddProfile<ProductProfile>()); // أو typeof(MappingProfile)


            builder.Services.AddScoped<ISerivceMnager, ServiceManger>();

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

            // ----------------------
            // 6️⃣ Build the app
            // ----------------------
            var app = builder.Build();

        
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