using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;

namespace RideOn.Domain.Abstrations.BusinessRules;

public  interface IRentalBusinessRules
{
    bool CanRent(DeliveryMan deliveryman);
    DateTimeOffset GetRentalStartDate(DateTimeOffset createdAt);
    DateTimeOffset GetExpectedEndDate(DateTimeOffset startDate, int planDays);
    decimal CalculateTotalCost(Rental rental, DateTimeOffset returnDate);
    decimal CalculateEarlyReturnPenalty(Rental rental, DateTimeOffset returnDate);
    decimal CalculateLateReturnCost(Rental rental, DateTimeOffset returnDate);
}
