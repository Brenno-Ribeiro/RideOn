using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.Cnh
{
    public record CnhRequest(
        [property: JsonPropertyName("imagem_cnh")] string CnhImage = "base64strings"
    );
}
