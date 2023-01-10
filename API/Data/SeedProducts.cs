using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SeedProducts
    {
        public static async Task ProductsSeed(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var productData = await System.IO.File.ReadAllTextAsync("Data/seed/ProductSeedData.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var products = JsonSerializer.Deserialize<List<Product>>(productData);
            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            

            await context.SaveChangesAsync();
        }
    }
} 