using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GossipBoard.Controllers
{
    [Route("api/demo")]
    public class DemoController : Controller
    {
        private readonly IDemoService _service;
        public DemoController(IDemoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(Car[]))]
        public async Task<IActionResult> Get([FromQuery]int offset = 0, [FromQuery]int limit = 10)
        {
            var cars = await _service.GetAllCars(offset, limit);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [Produces(typeof(Car))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _service.GetCarById(id);

            if (result == null)
            {
                return NotFound("Usefull data why it was not found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Produces(typeof(int))]
        public async Task<IActionResult> Post([FromBody]Car value)
        {
            var id = await _service.Create(value);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Car car)
        {
            var updatedCar = await _service.Update(car);

            return Ok(updatedCar);
        }
    }
}
