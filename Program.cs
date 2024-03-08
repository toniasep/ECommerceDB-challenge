using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerceDB.Models;
using ECommerceDB.Seeders;

namespace ECommerceDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ECommerceDbContext>();
                    context.Database.EnsureCreated(); // Pastikan basis data sudah dibuat
                    
                    //seeder
                    ProductCategorySeeder.Seed(context); // Jalankan seeder untuk data awal
                    CustomerOrderSeeder.Seed(context);
                }
                catch (Exception ex)
                {
                    // Handle error jika terjadi
                    Console.WriteLine(ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // Gunakan Startup class untuk konfigurasi aplikasi web
                });
    }
}
