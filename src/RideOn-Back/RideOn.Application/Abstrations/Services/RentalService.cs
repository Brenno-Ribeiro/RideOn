using AutoMapper;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;


namespace RideOn.Application.Abstrations.Services;

public class RentalService : IRentalService, IRentalBusinessRules
{
    private readonly IDeliveryManRepository? _deliveryManRepository;
    private readonly IMapper _mapper;

    public RentalService(IDeliveryManRepository? deliveryManRepository, IMapper mapper)
    {
        _deliveryManRepository = deliveryManRepository;
        _mapper = mapper;
    }
}
