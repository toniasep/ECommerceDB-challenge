using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerceDB.Models;
using ECommerceDB.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceDB.Seeders
{
    public static class CustomerOrderSeeder
    {
        public static void Seed(ECommerceDbContext context)
        {
            try
            {
                context.Database.BeginTransaction();

                if (!context.Customers.Any())
                {
                    var passwordHasher = new PasswordHasher<CustomerEntity>();
                    var customers = new List<CustomerEntity>
                    {
                        new CustomerEntity { Username = "john_doe", Email = "john_doe@dummy.com", Password = passwordHasher.HashPassword(null, "password1") },
                        new CustomerEntity { Username = "jane_doe", Email = "jane_doe@dummy.com", Password = passwordHasher.HashPassword(null, "password2") },
                        new CustomerEntity { Username = "bob_smith", Email = "bob_smith@dummy.com", Password = passwordHasher.HashPassword(null, "password3") },
                        new CustomerEntity { Username = "alice_johnson", Email = "alice_johnson@dummy.com", Password = passwordHasher.HashPassword(null, "password4") },
                        new CustomerEntity { Username = "charlie_brown", Email = "charlie_brown@dummy.com", Password = passwordHasher.HashPassword(null, "password5") }
                    };
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }
            context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
