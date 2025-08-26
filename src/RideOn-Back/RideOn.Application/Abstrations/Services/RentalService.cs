using AutoMapper;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Requests.Rental;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Application.DTOs.Responses.Rental;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;

namespace RideOn.Application.Abstrations.Services;

public class RentalService : IRentalService, IRentalBusinessRules
{
    private readonly IRentalRepository? _rentalRepository;
    private readonly IMapper _mapper;

    public RentalService(IRentalRepository? rentalRepository, IMapper mapper)
    {
        _rentalRepository = rentalRepository;
        _mapper = mapper;
    }

    public async Task<RentalResponse> GetRentalById(Guid id)
    {
        var rental = await _rentalRepository.GetByIdAsync(id);
        return _mapper.Map<RentalResponse>(rental);
    }

    public async Task<bool> SaveRental(RentalRequest rentalRequest)
    {
        var rental = _mapper.Map<Rental>(rentalRequest);
        return await _rentalRepository.SaveAsync(rental);
    }

    public async Task<bool> RentalReturn(Guid id, DateTimeOffset returnDate)
    {
        var rental = await _rentalRepository.GetByIdAsync(id);

        rental.UpdateReturnDate(returnDate);

        return await _rentalRepository.UpdateAsync(rental);

    }
}
