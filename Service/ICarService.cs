using jaarapi.Models;

namespace jaarapi.Service
{
    public interface ICarService
    {
        Task<CarData> GetFipeData(string codigoFipe, int ano);
        void RegisterCar(CarData car);
        CarData GetCarByPlate(string placa);
    }

}
