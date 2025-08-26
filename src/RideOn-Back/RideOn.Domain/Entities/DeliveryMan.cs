using RideOn.Domain.ValueObjects;

namespace RideOn.Domain.Entities;

public class DeliveryMan : Entity
{
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }

    public CNPJ? CNPJ { get; set; }
    public CNH? CNH { get; set; }

    public ICollection<Rental>? Rentals { get; set; } = new List<Rental>();


    public DeliveryMan()
    {
    }

    public DeliveryMan(string? name, DateTime birthDate, CNPJ? cNPJ, CNH? cNH)
    {
        Name = name;
        BirthDate = birthDate;
        CNPJ = cNPJ;
        CNH = cNH;
        Created_At = DateTime.UtcNow;
        Updated_At = DateTime.UtcNow;
        Created_by = Guid.NewGuid();
        Updated_by = Guid.NewGuid();
    }
}
