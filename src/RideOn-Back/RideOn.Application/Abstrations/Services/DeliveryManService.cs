using AutoMapper;
using RideOn.Application.DTOs.Requests.Cnh;
using RideOn.Application.DTOs.Requests.DeliveryMan;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;

namespace RideOn.Application.Abstrations.Services;

public class DeliveryManService : IDeliveryManService, IDeliveryManBusinessRules
{
    private readonly IDeliveryManRepository? _deliveryManRepository;
    private readonly IMapper _mapper;

    public DeliveryManService(IDeliveryManRepository? deliveryManRepository, IMapper mapper)
    {
        _deliveryManRepository = deliveryManRepository;
        _mapper = mapper;
    }

    public async Task<bool> SaveCnhImage(Guid id, CnhRequest cnhRequest)
    {
        return await _deliveryManRepository.SaveCnhImage(id, cnhRequest.CnhImage);
    }

    public async Task<bool> SaveDeliveryMan(DeliveryManRequest deliveryManRequest)
    {
        var deliveryMan = _mapper.Map<DeliveryMan>(deliveryManRequest);

        return await _deliveryManRepository.SaveAsync(deliveryMan);
    }

  
}
