using AutoMapper;
using RentCar.Interfaces;
using RentCar.Models;
using RentCar.Models.DTO_s.Car;
using RentCar.Models.Entities;
using System.Net;

namespace RentCar.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CreateAsync(CarCreateDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return new ServiceResponse<int>
                    {
                        Message = "Invalid car data",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                var mappedCar = _mapper.Map<Car>(dto);

                await _context.cars.AddAsync(mappedCar);
                await _context.SaveChangesAsync();

                return new ServiceResponse<int>
                {
                    Data = mappedCar.Id, Message = "Car added successfully",
                    StatusCode = HttpStatusCode.Created
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>
                {
                    Message = ex.GetFullMessage(),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }

        public Task<ServiceResponse<List<CarDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<string>>> GetAllCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CarDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CarDTO>>> GetByPhoneAsync(int number)
        {
            throw new NotImplementedException();
        }
    }
}
