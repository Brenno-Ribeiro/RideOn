using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.Rental
{
    public record ReturnDateRequest(
        [property: JsonPropertyName("data_devolucao")] DateTimeOffset ReturnDate
    );
}
