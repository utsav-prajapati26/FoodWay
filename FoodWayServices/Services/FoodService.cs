using FoodWayCore;
using FoodWayInfrastructure.Interfaces;
using FoodWayServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayServices.Services
{
    public class FoodService : IFoodService
    {
        public readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
        }

        public async Task<Food?> AddAsync(Food food)
        {
            return await _foodRepository.AddAsync(food);
            
        }

        public  Task DeleteAsync(int id)
        {
            return  _foodRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Food>> GetAllAsync()
        {
            return _foodRepository.GetAllAsync();
        }

        public Task<Food?> GetByIdAsync(int id)
        {
            return _foodRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Food food)
        {
            return _foodRepository.UpdateAsync(food);
        }
    }
}
