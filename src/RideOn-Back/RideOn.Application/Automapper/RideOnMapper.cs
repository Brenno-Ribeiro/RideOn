using AutoMapper;
using RideOn.Application.DTOs.Requests.DeliveryMan;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Requests.Rental;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Application.DTOs.Responses.Rental;
using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;

namespace RideOn.Application.Automapper;

public class RideOnMapper : Profile
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




        CreateMap<RentalRequest, Rental>()
            .ForMember(dest => dest.DeliveryManId, opt => opt.MapFrom(src => Guid.Parse(src.DeliveryManId)))
            .ForMember(dest => dest.MotorcycleId, opt => opt.MapFrom(src => Guid.Parse(src.MotorcycleId)))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.ExpectedEndDate, opt => opt.MapFrom(src => src.ExpectedEndDate))
            .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => src.Plan));


        CreateMap<Rental, RentalResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DailyRate, opt => opt.MapFrom(src => src.DailyRate))
            .ForMember(dest => dest.DeliveryManId, opt => opt.MapFrom(src => src.DeliveryManId))
            .ForMember(dest => dest.MotorcycleId, opt => opt.MapFrom(src => src.MotorcycleId))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.DateTime))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.DateTime))
            .ForMember(dest => dest.ExpectedEndDate, opt => opt.MapFrom(src => src.ExpectedEndDate.DateTime))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate));
    }
}
