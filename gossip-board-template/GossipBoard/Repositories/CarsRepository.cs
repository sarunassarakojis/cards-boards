using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Database;
using GossipBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Repositories
{
    public class CarsRepository : ICarRepository
    {
        private readonly DbSet<Car> _cars;
        private readonly DbContext _context;

        public CarsRepository(DemoDbContext context)
        {
            _cars = context.Cars;
            _context = context;
        }

        public async Task<Car> GetById(int id)
        {
            var car = await _cars.FindAsync(id);
            return car;
        }

        public async Task<ICollection<Car>> GetAll(int offset, int limit)
        {
            var cars = await _cars.Skip(offset).Take(limit).ToArrayAsync();
            return cars;
        }

        public async Task<int> Create(Car newCar)
        {
            //create unit of work
            await _cars.AddAsync(newCar);
            await _context.SaveChangesAsync();
            return newCar.Id;
        }

        public async Task<Car> Update(Car updatedCar)
        {
            var existingCar = _cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            _cars.Update(existingCar);

            MapUpdatedValues(existingCar, updatedCar);

            await _context.SaveChangesAsync();

            return existingCar;
        }

        private static void MapUpdatedValues(Car existingCar, Car updatedCar)
        {
            existingCar.ImageUrl = updatedCar.ImageUrl;
            existingCar.Model = updatedCar.Model;
            existingCar.OtherInformation = updatedCar.OtherInformation;
        }
    }
}
