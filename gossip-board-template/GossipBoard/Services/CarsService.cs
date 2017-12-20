using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Repositories;

namespace GossipBoard.Services
{
    public class CarsService : IDemoService
    {
        private readonly ICarRepository _repository;
        private readonly IMailService _mail;

        public CarsService(ICarRepository repository, IMailService mail)
        {
            _repository = repository;
            _mail = mail;
        }

        public async Task<Car> GetCarById(int id)
        {
            var car = await _repository.GetById(id);
            return car;
        }

        public async Task<ICollection<Car>> GetAllCars(int offset, int limit)
        {
            var cars = await _repository.GetAll(offset, limit);
            return cars;
        }

        public async Task<int> Create(Car car)
        {
            var newId = await _repository.Create(car);
            return newId;
        }

        public async Task<Car> Update(Car car)
        {
            var updatedCar = await _repository.Update(car);
            return updatedCar;
        }
    }
}
