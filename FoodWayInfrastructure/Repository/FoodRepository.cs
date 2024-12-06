using FoodWayCore;
using FoodWayInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayInfrastructure.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Food?> AddAsync(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            // Add the food entity to the context
            await _unitOfWork.Context.Set<Food>().AddAsync(food);
             await _unitOfWork.CommitAsync();

            return food;
        }


        public async Task DeleteAsync(int id)
        {
           var food = await GetByIdAsync(id);
            if (food != null)
            {
                _unitOfWork.Context.Set<Food>().Remove(food);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<Food>().ToListAsync();
        }

        public async Task<Food?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<Food>().FindAsync(id);
        }

        public  async Task<int> UpdateAsync(Food food)
        {
            int foodResult = 0;

            _unitOfWork.Context.Entry(food).State = EntityState.Modified;
            _unitOfWork.Context.Foods.Update(food);

            await _unitOfWork.CommitAsync();

            return food.Id;

        }

       

    }
}
//added