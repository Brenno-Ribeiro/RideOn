namespace RideOn.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTimeOffset Created_At { get; set; }
    public Guid Created_by { get;  set; }
    public DateTimeOffset Updated_At { get; set; }
    public Guid Updated_by { get; set; }
}
