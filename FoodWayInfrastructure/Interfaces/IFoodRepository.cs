using FoodWayCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayInfrastructure.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food?> GetByIdAsync(int id);
        Task<Food?> AddAsync(Food food);
        Task<int> UpdateAsync(Food food);
        Task DeleteAsync(int id);
    }
}
