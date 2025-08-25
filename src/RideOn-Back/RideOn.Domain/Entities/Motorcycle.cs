namespace RideOn.Domain.Entities;

public class Motorcycle : Entity
{
    public int Year { get; private set; }
    public string? Model { get; private set; }
    public string? Plate { get; private set; }

    public Rental? Rental { get; set; }

    public Motorcycle() { }

    public Motorcycle(int year, string model, string plate)
    {
        Year = year;
        Model = model;
        Plate = plate;
    }
}
