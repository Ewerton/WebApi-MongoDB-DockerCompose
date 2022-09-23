using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductAPI.Entities;

namespace ProductAPI.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
               ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
               ("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>
              ("DatabaseSettings:CollectionName"));

            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
