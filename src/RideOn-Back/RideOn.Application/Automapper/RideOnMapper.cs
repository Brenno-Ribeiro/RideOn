using AutoMapper;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Domain.Entities;

namespace RideOn.Application.Automapper;

public  class RideOnMapper : Profile
{
    public RideOnMapper()
    {
        CreateMap<MotorcycleRequest, Motorcycle>().ReverseMap();

        //Todo: Resolver o Mapeamento
        CreateMap<Motorcycle, MotorcycleResponse>()
            .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate.Number));
    }
}
