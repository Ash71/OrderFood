

using MongoDB.Driver;

namespace OrderFood.Models
{
    public interface IDbContext
    {
        IMongoCollection<FoodItem> FoodItem { get; }
    }
}
