using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemRepository _itemRepository;
        public FoodItemsController(IFoodItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _itemRepository.GetAllItems());
        }

        [HttpGet("{title}", Name = "Get")]
        public async Task<IActionResult> Get(string title)
        {
            var item = await _itemRepository.GetItemByTitle(title);
            if (item == null)
                return new NotFoundResult();
            return new ObjectResult(item);
        }

         
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FoodItem item)
        {
            await _itemRepository.Create(item);
            return new OkObjectResult(item);
        }


        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]FoodItem item)
        {
            var foodItem = await _itemRepository.GetItemById(id);
            if (foodItem == null)
                return new NotFoundResult();
            foodItem.Title = foodItem.Title;
            await _itemRepository.Update(foodItem);
            return new OkObjectResult(foodItem);
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _itemRepository.GetItemById(id);
            if (item == null)
                return new NotFoundResult();
            await _itemRepository.Delete(id);
            return new OkResult();
        }
    }
}
