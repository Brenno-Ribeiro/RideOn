namespace RideOn.Domain.Entities;

public class DeliveryMan : Entity
{
    public string? Name { get; set; }
    public string? CNPJ { get; set; }
    public DateTime BirthDate { get; set; }

    public CNH? CNH { get; set; }

    public ICollection<Rental>? Rentals { get; set; } = new List<Rental>();


    public DeliveryMan()
    {
    }

    public DeliveryMan(string? name, string? cNPJ, DateTime birthDate)
    {
        Name = name;
        CNPJ = cNPJ;
        BirthDate = birthDate;
    }

}
