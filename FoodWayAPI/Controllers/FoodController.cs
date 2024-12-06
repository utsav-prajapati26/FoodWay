using FoodWayCore;
using FoodWayServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodWayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService ?? throw new ArgumentNullException(nameof(foodService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetAll()
        {
            var foods = await _foodService.GetAllAsync();
            if (foods == null)
                return NotFound();

            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetById(int id)
        {
            var food = await _foodService.GetByIdAsync(id);

            if (food == null)
                return NotFound();

            return Ok(food);
        }




        [HttpPost]
        public async Task<ActionResult<Food>> CreateFood(Food food)
        {
            if (food == null)
            {
                return BadRequest("Food data is invalid.");
            }

            // Ensure the ID is ignored and auto-generated
            food.Id = 0;

            var result = await _foodService.AddAsync(food);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Food food)
        {
            if (id != food.Id)
                return BadRequest("Food ID mismatch");

            await _foodService.UpdateAsync(food);
            return NoContent(); // 204 No Content
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _foodService.GetByIdAsync(id);
            if (food == null)
                return NotFound();

            await _foodService.DeleteAsync(id);
            return NoContent(); // 204 No Content
        }

    }
}
