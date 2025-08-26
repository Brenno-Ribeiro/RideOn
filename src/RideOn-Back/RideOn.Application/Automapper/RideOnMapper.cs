using AutoMapper;
using RideOn.Application.DTOs.Requests.DeliveryMan;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;

namespace RideOn.Application.Automapper;

public  class RideOnMapper : Profile
{
    public RideOnMapper()
    {
        CreateMap<MotorcycleRequest, Motorcycle>().ReverseMap();

        //Todo: Resolver o Mapeamento
        CreateMap<Motorcycle, MotorcycleResponse>()
            .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate.Number));


        CreateMap<DeliveryMan, DeliveryManRequest>()
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.CNPJ != null ? src.CNPJ.Cnpj : null))
            .ForMember(dest => dest.CnhNumber, opt => opt.MapFrom(src => src.CNH != null ? src.CNH.CnhNumber : null))
            .ForMember(dest => dest.CnhType, opt => opt.MapFrom(src => src.CNH != null ? src.CNH.CnhType : null))
            .ForMember(dest => dest.CnhImage, opt => opt.MapFrom(src => src.CNH != null ? src.CNH.CnhImage : null));



        //Todo: Resolver o Data como infinity
        CreateMap<DeliveryManRequest, DeliveryMan>()
            .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Cnpj) ? new CNPJ(src.Cnpj) : null))
            .ForMember(dest => dest.CNH, opt => opt.MapFrom(src =>
                (!string.IsNullOrEmpty(src.CnhNumber) || !string.IsNullOrEmpty(src.CnhType) || !string.IsNullOrEmpty(src.CnhImage))
                ? new CNH
                {
                    CnhNumber = src.CnhNumber,
                    CnhType = src.CnhType,
                    CnhImage = src.CnhImage
                }
                : null
            ))
        .ForMember(dest => dest.Created_At, opt => opt.Ignore())
        .ForMember(dest => dest.Updated_At, opt => opt.Ignore())
        .ForMember(dest => dest.Created_by, opt => opt.Ignore())
        .ForMember(dest => dest.Updated_by, opt => opt.Ignore());

    }
}
