using RideOn.Domain.ValueObjects;

namespace RideOn.Domain.Entities;

public class Motorcycle : Entity
{
    public int Year { get; private set; }
    public string? Model { get; private set; }

    public Plate? Plate { get; private set; }
    public Rental? Rental { get; set; }

    public Motorcycle() { }

    public Motorcycle(int year, string? model, Plate plate)
    {
        Year = year;
        Model = model;
        Plate = plate;
        Created_At = DateTime.UtcNow;
        Updated_At = DateTime.UtcNow;
        Created_by = Guid.NewGuid();
        Updated_by = Guid.NewGuid();
    }
}
