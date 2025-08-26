using Microsoft.AspNetCore.Mvc;
using RideOn.Application.Abstrations.Services;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Requests.Plate;

namespace RideOn.API.Controllers
{
    [ApiController]
    [Route("motos")]
    [Tags("motos")]
    public class MotorcycleController : ControllerBase
    {
        private readonly ILogger<MotorcycleController> _logger;
        private readonly IMotocycleService _motocycleService;

        public MotorcycleController(ILogger<MotorcycleController> logger, IMotocycleService motocycleService)
        {
            _logger = logger;
            _motocycleService = motocycleService;
        }

        [HttpPost(Name = "SaveMotorcycle")]
        public async Task<IActionResult> SaveMotorcycle(MotorcycleRequest motorcycleRequest)
        {
            var result = await _motocycleService.SaveMotorcycle(motorcycleRequest);

            return StatusCode(201,result);
        }


        [HttpGet(Name = "GetMotorcycleByPlate")]
        public async Task<IActionResult> GetMotorcycleByPlate(string plate)
        {
            var result = await _motocycleService.GetMotorcyclesByPlate(plate);

            return StatusCode(200, result);
        }


        [HttpPut("{id}/placa", Name = "UpdatePlateMotorcycle")]
        public async Task<IActionResult> UpdatePlateMotorcycle(Guid id,PlateRequest plate)
        {
            var result = await _motocycleService.UpdatePlateMotorcycle(id, plate.Number);

            return StatusCode(200, new {mensagem = "Placa modifica com sucesso"});
        }


        [HttpGet("{id}",Name = "GetMotorcycleById")]
        public async Task<IActionResult> GetMotorcycleById(Guid id)
        {
            var result = await _motocycleService.GetMotorcycleById(id);

            if (result == null)
                return StatusCode(404, new { mensagem = "Moto não encontrada" });

            return StatusCode(200, result);
        }


        [HttpDelete("{id}", Name = "DeleteMotorcycle")]
        public async Task<IActionResult> DeleteMotorcycle(Guid id)
        {
            var result = await _motocycleService.DeleteMotorcycle(id);

            if (!result)
            {
                return StatusCode(400, new { mensagem = "Moto não pode excluida, pois está alugada!" });
            }

            return StatusCode(200, result);
        }
    }
}
