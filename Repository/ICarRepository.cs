using jaarapi.Models;

namespace jaarapi.Repository
{
    public interface ICarRepository
    {
        IEnumerable<CarData> GetAllCars();
        CarData GetCarByPlate(string plate);
        void AddCar(CarData car);
        void SaveChanges();
    }
}
