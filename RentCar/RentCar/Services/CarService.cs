using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

                Car mappedCar = _mapper.Map<Car>(dto);

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

        public async Task<ServiceResponse<List<CarDTO>>> GetAllAsync()
        {
            try
            {
                List<CarDTO> cars = await _context.cars.Select(x => _mapper.Map<CarDTO>(x)).ToListAsync();
                return new ServiceResponse<List<CarDTO>> { Data = cars, Message = "Cars returned successfully", StatusCode = HttpStatusCode.OK };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<CarDTO>>
                {
                    Message = ex.GetFullMessage(),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }

        public Task<ServiceResponse<List<string>>> GetAllCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<CarDTO>>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            try
            {
                int totalCars = await _context.cars.CountAsync();

                List<CarDTO> carsQuery = await _context.cars.Select(x => _mapper.Map<CarDTO>(x)).ToListAsync();

                List<CarDTO> cars = carsQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                if (cars.Count == 0)
                    return new ServiceResponse<List<CarDTO>> { Message = "Page is empty", StatusCode = HttpStatusCode.ExpectationFailed };


                return new ServiceResponse<List<CarDTO>> { Data = cars, Message = "Paginated cars returned successfully", StatusCode = HttpStatusCode.OK };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<CarDTO>> { Message = ex.GetFullMessage(), StatusCode = HttpStatusCode.BadRequest };
            }
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
