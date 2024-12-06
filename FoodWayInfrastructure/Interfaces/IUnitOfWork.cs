using FoodWayCore;
using FoodWayInfrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWayInfrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        //void CommitAsync();
        Task CommitAsync();
    }
}
