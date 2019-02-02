using MongoDB.Driver;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFood.Data
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly IDbContext _context;
        public FoodItemRepository(IDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FoodItem>> GetAllItems()
        {
            return await _context
                            .FoodItem
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<FoodItem> GetItemById(string id)
        {
            FilterDefinition<FoodItem> filter = Builders<FoodItem>.Filter.Eq(m => m.Id.ToString(), id);
            return _context
                    .FoodItem
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<FoodItem> GetItemByTitle(string title)
        {
            FilterDefinition<FoodItem> filter = Builders<FoodItem>.Filter.Eq(m => m.Title, title);
            return _context
                    .FoodItem
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(FoodItem item)
        {
            await _context.FoodItem.InsertOneAsync(item);
        }
        public async Task<bool> Update(FoodItem item)
        {
            ReplaceOneResult updateResult =
                await _context
                        .FoodItem
                        .ReplaceOneAsync(
                            filter: g => g.Id == item.Id,
                            replacement: item);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<FoodItem> filter = Builders<FoodItem>.Filter.Eq(m => m.Id.ToString(), id);
            DeleteResult deleteResult = await _context
                                                .FoodItem
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
