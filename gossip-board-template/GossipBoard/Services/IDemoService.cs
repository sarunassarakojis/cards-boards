using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;

namespace GossipBoard.Services
{
    public interface IDemoService
    {
        Task<Car> GetCarById(int id);

        Task<ICollection<Car>> GetAllCars(int offset, int limit);

        Task<int> Create(Car car);

        Task<Car> Update(Car car);
    }
}
