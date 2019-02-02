using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFood.Models
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> GetAllItems();
        Task<FoodItem> GetItemByTitle(string title);
        Task<FoodItem> GetItemById(string id);
        Task Create(FoodItem item);
        Task<bool> Update(FoodItem item);
        Task<bool> Delete(string id);
    }
}
