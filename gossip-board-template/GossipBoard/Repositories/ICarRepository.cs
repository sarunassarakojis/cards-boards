using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;

namespace GossipBoard.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetById(int id);
        Task<ICollection<Car>> GetAll(int offset, int limit);
        Task<int> Create(Car newCar);
        Task<Car> Update(Car updatedCar);
    }
}
