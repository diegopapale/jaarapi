using jaarapi.Models;
using jaarapi.Repository;
using System.Security.Cryptography.Xml;

namespace jaarapi.Service
{
    public class CarService : ICarService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICarRepository _carRepository;

        public CarService(IHttpClientFactory clientFactory, ICarRepository carRepository)
        {
            _clientFactory = clientFactory;
            _carRepository = carRepository;
        }

        public async Task<CarData> GetFipeData(string codigoFipe, int ano)
        {
            var client = _clientFactory.CreateClient("BrasilAPI");
            var response = await client.GetAsync($"{codigoFipe}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<CarData>>();
                return data.Where(c => c.AnoModelo == ano).FirstOrDefault();
            }
            return null;
        }

        public void RegisterCar(CarData car)
        {
            _carRepository.AddCar(car);
            _carRepository.SaveChanges();
        }

        public CarData GetCarByPlate(string placa)
        {
            return _carRepository.GetCarByPlate(placa);
        }
    }
}
