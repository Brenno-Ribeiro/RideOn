using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Responses.Motorcycle
{
    public record MotorcycleResponse
    (
        [property: JsonPropertyName("identificador")] Guid id,
        [property: JsonPropertyName("ano")] int Year,
        [property: JsonPropertyName("modelo")] string Model,
        [property: JsonPropertyName("placa")] string Plate
    );

}
