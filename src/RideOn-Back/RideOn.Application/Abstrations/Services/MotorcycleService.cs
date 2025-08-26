using AutoMapper;
using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Responses.Motorcycle;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;


namespace RideOn.Application.Abstrations.Services;

public class MotorcycleService : IMotocycleService, IMotorcycleBusinessRules
{
    private readonly IMotorcycleRepository? _motorcycleRepository;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository? motorcycleRepository, IMapper mapper)
    {
        _motorcycleRepository = motorcycleRepository;
        _mapper = mapper;
    }

    public bool CheckPlate(Plate plate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteMotorcycle(Guid id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        return await _motorcycleRepository.DeleteAsync(motorcycle);
    }

    public async Task<MotorcycleResponse> GetMotorcycleById(Guid id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        return _mapper.Map<MotorcycleResponse>(motorcycle);
    }

    public async Task<List<MotorcycleResponse>> GetMotorcyclesByPlate(string plate)
    {

        var motorcycle = await _motorcycleRepository.GetMotorcycleByPlate(plate);

        // transforma em lista
        var motorcycles = new List<Motorcycle> { motorcycle };

        // mapeia a lista inteira para DTO
        var dtos = _mapper.Map<List<MotorcycleResponse>>(motorcycles);

        return dtos;

    }

    public async Task<bool> SaveMotorcycle(MotorcycleRequest motorcycleRequest)
    {
        var motorcycle = _mapper.Map<Motorcycle>(motorcycleRequest);

        return await _motorcycleRepository.SaveAsync(motorcycle);
    }

    public async Task<bool> UpdatePlateMotorcycle(Guid id, string plate)
    {
       var motorcycle = await _motorcycleRepository.UpdatePlate(id, plate);

       return motorcycle;
    }
}
