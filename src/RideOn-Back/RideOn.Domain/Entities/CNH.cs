namespace RideOn.Domain.Entities;

public class CNH : Entity
{
    public string? CnhNumber { get; set; }
    public string? CnhType { get; set; }
    public string? CnhImage { get; set; }

    public Guid DeliveryManId { get; set; }
    public DeliveryMan? DeliveryMan { get; set; }

    public CNH() { }

    public CNH(string? cnhNumber, string? cnhType, string cnhImage)
    {
        CnhNumber = cnhNumber;
        CnhType = cnhType;
        CnhImage = cnhImage;
    }
}
