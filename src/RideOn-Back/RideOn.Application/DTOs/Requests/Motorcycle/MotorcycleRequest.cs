using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.Motorcycle;

public record MotorcycleRequest(

    [property: JsonPropertyName("identificador")] Guid id,
    [property: JsonPropertyName("ano")] int Year,
    [property: JsonPropertyName("modelo")] string Model,
    [property: JsonPropertyName("placa")] string Plate
);
  
