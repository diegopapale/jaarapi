using jaarapi.Data;
using jaarapi.Models;

namespace jaarapi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarData> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public CarData GetCarByPlate(string plate)
        {
            return _context.Cars.FirstOrDefault(c => c.Placa == plate);
        }

        public void AddCar(CarData car)
        {
            _context.Cars.Add(car);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
