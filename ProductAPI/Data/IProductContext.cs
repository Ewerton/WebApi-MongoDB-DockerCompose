using MongoDB.Driver;
using ProductAPI.Entities;

namespace ProductAPI.Data
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
