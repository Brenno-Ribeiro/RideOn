using Microsoft.AspNetCore.Mvc;
using RideOn.Application.Abstrations.Services;
using RideOn.Application.DTOs.Requests.Cnh;
using RideOn.Application.DTOs.Requests.DeliveryMan;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Requests.Rental;

namespace RideOn.API.Controllers
{
    [ApiController]
    [Route("locação")]
    [Tags("locação")]
    public class RentalController : ControllerBase
    {
        private readonly ILogger<RentalController> _logger;
        private readonly IRentalService _rentalService;

        public RentalController(ILogger<RentalController> logger, IRentalService rentalService)
        {
            _logger = logger;
            _rentalService = rentalService;
        }


        [HttpPost("", Name = "SaveRental")]
        public async Task<IActionResult> SaveRental(RentalRequest rentalRequest)
        {
            var result = await _rentalService.SaveRental(rentalRequest);
            return StatusCode(200, result);
        }

        [HttpGet(Name = "GetRentalById")]
        public async Task<IActionResult> GetRentalById(Guid id)
        {
            var result = await _rentalService.GetRentalById(id);
            return StatusCode(201,result);
        }


        [HttpPut( "{id}/devolucao",Name = "RentalReturn")]
        public async Task<IActionResult> RentalReturn(Guid id, ReturnDateRequest returnDateRequest)
        {
            var result = await _rentalService.RentalReturn(id, returnDateRequest.ReturnDate);
            return StatusCode(200, result);
        }

       
    }
}
