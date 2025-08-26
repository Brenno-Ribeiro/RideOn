using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.Plate;

public record PlateRequest(
    [property: JsonPropertyName("placa")] string Number
);