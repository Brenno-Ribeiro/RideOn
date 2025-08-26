using AutoMapper;
using RideOn.Application.DTOs.Requests.Rental;
using RideOn.Application.DTOs.Responses.Rental;
using RideOn.Domain.Abstrations.BusinessRules;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;

namespace RideOn.Application.Abstrations.Services;

public class RentalService : IRentalService, IRentalBusinessRules
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IMapper _mapper;

    // tabela de preços (poderia ir para config/tabela no banco coloquei aqui só como demostração demostração)
    private readonly Dictionary<int, decimal> _plans = new()
    {
        {7, 30m},   // 7 dias -> R$30/dia
        {15, 28m},  // 15 dias -> R$28/dia
        {30, 25m},  // 30 dias -> R$25/dia
        {45, 23m},  // 45 dias -> R$23/dia
        {50, 20m}   // 50 dias -> R$20/dia
    };

    public RentalService(IRentalRepository rentalRepository, IMapper mapper)
    {
        _rentalRepository = rentalRepository;
        _mapper = mapper;
    }

    #region Regras de negócio

    public bool CanRent(DeliveryMan deliveryman) =>
        deliveryman.CNH.CnhType.Contains("A");

    public DateTimeOffset GetRentalStartDate(DateTimeOffset createdAt) =>
        createdAt.AddDays(1);

    public DateTimeOffset GetExpectedEndDate(DateTimeOffset startDate, int plan) =>
        startDate.AddDays(plan);

    public decimal CalculateTotalCost(Rental rental, DateTimeOffset returnDate)
    {
        if (returnDate < rental.ExpectedEndDate)
            return CalculateEarlyReturnPenalty(rental, returnDate);

        if (returnDate > rental.ExpectedEndDate)
            return CalculateLateReturnCost(rental, returnDate);

        // devolveu no prazo certinho
        return rental.Plan * _plans[rental.Plan];
    }

    public decimal CalculateEarlyReturnPenalty(Rental rental, DateTimeOffset returnDate)
    {
        var usedDays = (returnDate - rental.StartDate).Days;
        var unusedDays = rental.Plan - usedDays;

        decimal dailyRate = _plans[rental.Plan];
        decimal totalUsed = usedDays * dailyRate;

        decimal penaltyPercent = rental.Plan switch
        {
            7 => 0.20m,
            15 => 0.40m,
            _ => 0.50m
        };

        decimal penalty = unusedDays * dailyRate * penaltyPercent;
        return totalUsed + penalty;
    }

    public decimal CalculateLateReturnCost(Rental rental, DateTimeOffset returnDate)
    {
        var lateDays = (returnDate - rental.ExpectedEndDate).Days;
        decimal dailyRate = _plans[rental.Plan];

        var baseCost = rental.Plan * dailyRate;
        var extraCost = lateDays * 50m;

        return baseCost + extraCost;
    }

    #endregion

    #region Métodos do serviço

    public async Task<RentalResponse> GetRentalById(Guid id)
    {
        var rental = await _rentalRepository.GetByIdAsync(id);
        return _mapper.Map<RentalResponse>(rental);
    }

    public async Task<bool> SaveRental(RentalRequest rentalRequest)
    {
        var rental = _mapper.Map<Rental>(rentalRequest);

        rental.StartDate = GetRentalStartDate(DateTimeOffset.UtcNow);
        rental.ExpectedEndDate = GetExpectedEndDate(rental.StartDate, rental.Plan);

        return await _rentalRepository.SaveAsync(rental);
    }

    public async Task<bool> RentalReturn(Guid id, DateTimeOffset returnDate)
    {
        var rental = await _rentalRepository.GetByIdAsync(id);

        rental.UpdateReturnDate(returnDate);

        var totalCost = CalculateTotalCost(rental, returnDate);

        rental.DailyRate = totalCost;

        return await _rentalRepository.UpdateAsync(rental);
    }

    #endregion
}
