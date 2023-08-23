using jaarapi.Models;
using jaarapi.Service;
using Microsoft.AspNetCore.Mvc;

namespace jaarapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("fipe")]
        public async Task<IActionResult> GetFipeData(string codigoFipe, int ano)
        {
            var data = await _carService.GetFipeData(codigoFipe, ano);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest("Erro ao buscar dados na BrasilAPI.");
        }

        [HttpPost("register")]
        public IActionResult RegisterCar(CarData carData)
        {
            try
            {
                _carService.RegisterCar(carData);
                return Ok("Carro registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao registrar o carro: {ex.Message}");
            }
        }

        [HttpGet("{placa}")]
        public IActionResult GetCarByPlate(string placa)
        {
            var car = _carService.GetCarByPlate(placa);
            if (car != null)
                return Ok(car);
            return NotFound("Carro não encontrado.");
        }
    }
}
