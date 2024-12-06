using FoodWayCore;
using FoodWayInfrastructure.Context;
using FoodWayInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayInfrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            if (context == null)
            {
                Console.WriteLine("ApplicationDbContext is null.");
            }

            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CommitAsync()
        {
                await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
