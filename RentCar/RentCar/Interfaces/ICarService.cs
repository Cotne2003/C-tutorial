using RentCar.Models.DTO_s.Car;

namespace RentCar.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDTO>> GetAllAsync();
    }
}
