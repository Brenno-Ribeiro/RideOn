namespace RideOn.Domain.Entities;

public class Rental : Entity
{
    public decimal DailyRate { get; set; }
    public int Plan { get; set; }

    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public DateTimeOffset ExpectedEndDate { get; set; }
    public DateTimeOffset ReturnDate { get; set; }

    public Guid DeliveryManId { get; set; }
    public DeliveryMan? DeliveryMan { get; set; }

    public Guid MotorcycleId { get; set; }
    public Motorcycle? Motorcycle { get; set; }

    public Rental()
    {
            
    }

    public void UpdateReturnDate(DateTimeOffset returnDate) => ReturnDate = returnDate;

    public Rental(decimal dailyRate, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset expectedEndDate, DateTimeOffset returnDate, DeliveryMan? deliveryMan, Motorcycle? motorcycle)
    {
        DailyRate = dailyRate;
        StartDate = startDate;
        EndDate = endDate;
        ExpectedEndDate = expectedEndDate;
        ReturnDate = returnDate;
        DeliveryMan = deliveryMan;
        Motorcycle = motorcycle;
        Created_At = DateTime.UtcNow;
        Updated_At = DateTime.UtcNow;
        Created_by = Guid.NewGuid();
        Updated_by = Guid.NewGuid();
    }
}
