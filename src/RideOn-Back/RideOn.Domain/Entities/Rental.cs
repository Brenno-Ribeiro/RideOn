namespace RideOn.Domain.Entities;

public class Rental : Entity
{
    public decimal DailyRate { get; private set; }

    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    public DateTimeOffset ExpectedEndDate { get; private set; }
    public DateTimeOffset ReturnDate { get; private set; }

    public Guid DeliveryManId { get; set; }
    public DeliveryMan? DeliveryMan { get; private set; }

    public Guid MotorcycleId { get; set; }
    public Motorcycle? Motorcycle { get; private set; }

    public Rental()
    {
            
    }

    public Rental(decimal dailyRate, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset expectedEndDate, DateTimeOffset returnDate, DeliveryMan? deliveryMan, Motorcycle? motorcycle)
    {
        DailyRate = dailyRate;
        StartDate = startDate;
        EndDate = endDate;
        ExpectedEndDate = expectedEndDate;
        ReturnDate = returnDate;
        DeliveryMan = deliveryMan;
        Motorcycle = motorcycle;
    }
}
