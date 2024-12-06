using FoodWayCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayServices.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food?> GetByIdAsync(int id);
        Task<Food?> AddAsync(Food food);
        Task UpdateAsync(Food food);
        Task DeleteAsync(int id);
    }
}
