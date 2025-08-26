using System.Text.Json.Serialization;

namespace RideOn.Application.DTOs.Requests.DeliveryMan;

public record DeliveryManRequest(
    [property: JsonPropertyName("identificador")] Guid Id,
    [property: JsonPropertyName("nome")] string Name,
    [property: JsonPropertyName("cnpj")] string Cnpj,
    [property: JsonPropertyName("data_nascimento")] DateTime BirthDate,
    [property: JsonPropertyName("numero_cnh")] string CnhNumber,
    [property: JsonPropertyName("tipo_cnh")] string CnhType,
    [property: JsonPropertyName("imagem_cnh")] string CnhImage
);


