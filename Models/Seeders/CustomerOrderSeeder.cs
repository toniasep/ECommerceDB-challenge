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
                        new() { Username = "john_doe", Email = "john_doe@dummy.com", Password = passwordHasher.HashPassword(null, "password1"), ShippingAddress = "123 Main St" },
                        new() { Username = "jane_doe", Email = "jane_doe@dummy.com", Password = passwordHasher.HashPassword(null, "password2"), ShippingAddress = "456 Elm St" },
                        new() { Username = "bob_smith", Email = "bob_smith@dummy.com", Password = passwordHasher.HashPassword(null, "password3"), ShippingAddress = "789 Oak St" },
                        new() { Username = "alice_johnson", Email = "alice_johnson@dummy.com", Password = passwordHasher.HashPassword(null, "password4"), ShippingAddress = "321 Pine St" },
                        new() { Username = "charlie_brown", Email = "charlie_brown@dummy.com", Password = passwordHasher.HashPassword(null, "password5"), ShippingAddress = "654 Cedar St" }
                    };
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }

                if (!context.Orders.Any())
                {
                    var customers = context.Customers.ToList();
                    var products = context.Products.ToList();
                    var random = new Random();
                    var payment_methods = new List<string> { "Credit Card", "Debit Card", "PayPal", "Cash" };
                    var status = new List<string> { "Pending", "Processing", "Shipped", "Delivered" };
                    var orders = new List<OrderEntity>();
                    foreach (var customer in customers)
                    {
                        var order = new OrderEntity
                        {
                            CustomerId = customer.Id,
                            OrderDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                            ShippingAddress = customer.ShippingAddress,
                            PaymentMethod = payment_methods[random.Next(payment_methods.Count)],
                            Status = status[random.Next(status.Count)]

                        };
                        var orderItems = new List<OrderItemEntity>();
                        for (var i = 0; i < 10; i++)
                        {
                            var product = products[random.Next(products.Count)];
                            orderItems.Add(new OrderItemEntity
                            {
                                ProductId = product.Id,
                                Quantity = random.Next(1, 10)
                            });
                        }
                        order.OrderItems = orderItems;
                        orders.Add(order);
                    }
                    context.Orders.AddRange(orders);
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
