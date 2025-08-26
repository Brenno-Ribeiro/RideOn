using RideOn.Domain.Entities;

namespace RideOn.Domain.ValueObjects;

public sealed class CNH
{
    public string? CnhNumber { get; set; }
    public string? CnhType { get; set; }
    public string? CnhImage { get; set; }

    public CNH() { }

    public CNH(string? cnhNumber, string? cnhType, string cnhImage)
    {
        CnhNumber = cnhNumber;
        CnhType = cnhType;
        CnhImage = cnhImage;
    }
}
