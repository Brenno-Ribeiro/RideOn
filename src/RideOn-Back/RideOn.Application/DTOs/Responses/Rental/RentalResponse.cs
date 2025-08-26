using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Responses.Rental;


public record RentalResponse(
    [property: JsonPropertyName("identificador")] Guid Id,
    [property: JsonPropertyName("valor_diaria")] decimal DailyRate,
    [property: JsonPropertyName("entregador_id")] Guid DeliveryManId,
    [property: JsonPropertyName("moto_id")] Guid MotorcycleId,
    [property: JsonPropertyName("data_inicio")] DateTimeOffset StartDate,
    [property: JsonPropertyName("data_termino")] DateTimeOffset EndDate,
    [property: JsonPropertyName("data_previsao_termino")] DateTimeOffset ExpectedEndDate,
    [property: JsonPropertyName("data_devolucao")] DateTimeOffset? ReturnDate
);
