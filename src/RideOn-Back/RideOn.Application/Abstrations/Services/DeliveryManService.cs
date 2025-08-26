using AutoMapper;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;


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
}
