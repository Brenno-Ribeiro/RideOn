using RideOn.Application.DTOs.Requests.Rental;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Application.DTOs.Responses.Rental;

namespace RideOn.Application.Abstrations.Services;

public interface IRentalService
{
    Task<bool> SaveRental(RentalRequest rentalRequest);

    Task<RentalResponse> GetRentalById(Guid id);

    Task<bool> RentalReturn(Guid id,DateTimeOffset returnDate);

}

