using RentCar.Models;
using RentCar.Models.DTO_s.Car;

namespace RentCar.Interfaces
{
    public interface ICarService
    {
        Task<ServiceResponse<List<CarDTO>>> GetAllAsync();
        Task<ServiceResponse<int>> CreateAsync(CarCreateDTO dto);
        Task<ServiceResponse<List<CarDTO>>> GetByPhoneAsync(int number);
        Task<ServiceResponse<List<string>>> GetAllCitiesAsync();
        Task<ServiceResponse<CarDTO>> GetByIdAsync(int id);
    }
}
