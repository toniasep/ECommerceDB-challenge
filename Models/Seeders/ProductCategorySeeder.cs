using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerceDB.Models;
using ECommerceDB.Models.Entities;

namespace ECommerceDB.Seeders
{
    public static class ProductCategorySeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new ECommerceDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>());

            try
            {
                context.Database.BeginTransaction();

                if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(
                            new CategoryEntity { Name = "Men's Clothing" },
                            new CategoryEntity { Name = "Women's Clothing" },
                            new CategoryEntity { Name = "Electronics" }
                        );

                        context.SaveChanges();

                    }
                
                if (!context.Products.Any())
                    {
                        var menClothingCategory = context.Categories.FirstOrDefault(c => c.Name == "Men's Clothing");
                        var womenClothingCategory = context.Categories.FirstOrDefault(c => c.Name == "Women's Clothing");
                        var electronicsCategory = context.Categories.FirstOrDefault(c => c.Name == "Electronics");

                        //sub categories
                        context.Categories.AddRange(
                            new CategoryEntity { Name = "T-shirt", ParentCategoryId = menClothingCategory.Id },
                            new CategoryEntity { Name = "Jeans", ParentCategoryId = menClothingCategory.Id },
                            new CategoryEntity { Name = "Dress", ParentCategoryId = womenClothingCategory.Id },
                            new CategoryEntity { Name = "Smartphone", ParentCategoryId = electronicsCategory.Id },
                            new CategoryEntity { Name = "Laptop", ParentCategoryId = electronicsCategory.Id },
                            new CategoryEntity { Name = "Headphones", ParentCategoryId = electronicsCategory.Id },
                            new CategoryEntity { Name = "Smartwatch", ParentCategoryId = electronicsCategory.Id },
                            new CategoryEntity { Name = "Speaker", ParentCategoryId = electronicsCategory.Id }
                        );

                        context.Products.AddRange(
                            new ProductEntity { Name = "Men's T-shirt - Blue", Price = 153499, InventoryQuantity = 50, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Men's T-shirt - Black", Price = 123499, InventoryQuantity = 40, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Men's T-shirt - Gray", Price = 143499, InventoryQuantity = 30, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Men's Jeans", Price = 293499, InventoryQuantity = 20, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Women's Dress - Floral", Price = 393499, InventoryQuantity = 25, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Smartphone - Android", Price = 2993499, InventoryQuantity = 15, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Laptop - 15 inch", Price = 7993499, InventoryQuantity = 10, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Headphones - Wireless", Price = 793499, InventoryQuantity = 20, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Smartwatch - Fitness Tracker", Price = 1493499, InventoryQuantity = 30, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                            new ProductEntity { Name = "Speaker - Bluetooth", Price = 993499, InventoryQuantity = 15, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." }
                        );

                        context.SaveChanges();
                        
                        var products = context.Products.ToList();

                        context.ProductCategories.AddRange(
                            new ProductCategoryEntity { ProductId = products[0].Id, CategoryId = menClothingCategory.Id },
                            new ProductCategoryEntity { ProductId = products[1].Id, CategoryId = menClothingCategory.Id },
                            new ProductCategoryEntity { ProductId = products[2].Id, CategoryId = womenClothingCategory.Id },
                            new ProductCategoryEntity { ProductId = products[3].Id, CategoryId = menClothingCategory.Id },
                            new ProductCategoryEntity { ProductId = products[4].Id, CategoryId = womenClothingCategory.Id },
                            new ProductCategoryEntity { ProductId = products[5].Id, CategoryId = electronicsCategory.Id },
                            new ProductCategoryEntity { ProductId = products[6].Id, CategoryId = electronicsCategory.Id },
                            new ProductCategoryEntity { ProductId = products[7].Id, CategoryId = electronicsCategory.Id },
                            new ProductCategoryEntity { ProductId = products[8].Id, CategoryId = electronicsCategory.Id },
                            new ProductCategoryEntity { ProductId = products[9].Id, CategoryId = electronicsCategory.Id },
                            new ProductCategoryEntity { ProductId = products[0].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "T-shirt").Id },
                            new ProductCategoryEntity { ProductId = products[1].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "T-shirt").Id },
                            new ProductCategoryEntity { ProductId = products[2].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "T-shirt").Id },
                            new ProductCategoryEntity { ProductId = products[3].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Jeans").Id },
                            new ProductCategoryEntity { ProductId = products[4].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Dress").Id },
                            new ProductCategoryEntity { ProductId = products[5].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Smartphone").Id },
                            new ProductCategoryEntity { ProductId = products[6].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Laptop").Id },
                            new ProductCategoryEntity { ProductId = products[7].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Headphones").Id },
                            new ProductCategoryEntity { ProductId = products[8].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Smartwatch").Id },
                            new ProductCategoryEntity { ProductId = products[9].Id, CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Speaker").Id }
                            
                        );

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
