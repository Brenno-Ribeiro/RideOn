using Microsoft.AspNetCore.Mvc;
using RideOn.Application.Abstrations.Services;
using RideOn.Application.DTOs.Requests.Cnh;
using RideOn.Application.DTOs.Requests.DeliveryMan;

namespace RideOn.API.Controllers
{
    [ApiController]
    [Route("entregadores")]
    [Tags("entregadores")]
    public class DeliveryManController : ControllerBase
    {
        private readonly ILogger<DeliveryManController> _logger;
        private readonly IDeliveryManService _deliveryManService;

        public DeliveryManController(ILogger<DeliveryManController> logger, IDeliveryManService deliveryManService)
        {
            _logger = logger;
            _deliveryManService = deliveryManService;
        }


        [HttpPost(Name = "SaveDeliveryMan")]
        public async Task<IActionResult> SaveDeliveryMan(DeliveryManRequest deliveryManRequest)
        {
            var result = await _deliveryManService.SaveDeliveryMan(deliveryManRequest);
            return StatusCode(201,result);
        }


        [HttpPost( "{id}/cnh",Name = "SaveCnhImage")]
        public async Task<IActionResult> SaveCnhImage(Guid id,CnhRequest cnhRequest)
        {
            var result = await _deliveryManService.SaveCnhImage(id, cnhRequest);
            return StatusCode(200, result);
        }

       
    }
}
