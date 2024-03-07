using System;
using System.Linq;
using ECommerceDB.Models;
using ECommerceDB.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerceDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer("server=localhost;database=ecomerce;user=sa;password=SuksesBersama((99!!!))")); 
                
            var serviceProvider = services.BuildServiceProvider();

            ProductCategorySeeder.Seed(serviceProvider);
            
            var builder = CreateHostBuilder(args);

            var app = builder.Build();

            app.Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);
    }
}
