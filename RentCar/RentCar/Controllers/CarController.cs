using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Interfaces;
using RentCar.Models;
using RentCar.Models.DTO_s.Car;

namespace RentCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<CarDTO>>> GetAllAsync()
        {
            return await _carService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ServiceResponse<int>> CreateAsync(CarCreateDTO dto)
        {
            return await _carService.CreateAsync(dto);
        }

        [HttpGet("paginated")]
        public async Task<ServiceResponse<List<CarDTO>>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _carService.GetAllPaginatedAsync(pageNumber, pageSize);
        }
    }
}
