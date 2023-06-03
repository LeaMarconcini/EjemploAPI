﻿using Microsoft.AspNetCore.Mvc;
using ejemploApi.Data.Repositorios;
using ejemploApi.Model;

namespace Ejemplo.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _carRepository.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _carRepository.InsertCar(car);

            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _carRepository.UpdateCar(car);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCar(new Car { id = id });

            return NoContent();
        }


    }
}
