using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.Rental;

    public record RentalRequest(
    [property: JsonPropertyName("entregador_id")] string DeliveryManId,
    [property: JsonPropertyName("moto_id")] string MotorcycleId,
    [property: JsonPropertyName("data_inicio")] DateTimeOffset StartDate,
    [property: JsonPropertyName("data_termino")] DateTimeOffset EndDate,
    [property: JsonPropertyName("data_previsao_termino")] DateTimeOffset ExpectedEndDate,
    [property: JsonPropertyName("plano")] int Plan
);
