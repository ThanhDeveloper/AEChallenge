using AEPortal.Bussiness.ResponseModel;
using AEPortal.Bussiness.UnitOfWorks;
using AEPortal.Bussiness.ViewModel;
using AEPortal.Common.Exceptions;
using AEPortal.Common.Extentions;
using AEPortal.Common.Models;
using AEPortal.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AEPortal.Bussiness.Services;
public interface IShipService
{
    Task<PageList<ShipResponseDto>> GetShips(ShipSearchViewModel shipSearchViewModel);
    Task<Ship> Create(ShipCreateViewModel shipCreateViewModel);
    Task Update(ShipUpdateViewModel shipUpdateViewModel, Guid id);
}

public class ShipService : IShipService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ShipService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Ship> Create(ShipCreateViewModel shipCreateViewModel)
    {
        var ship = _mapper.Map<Ship>(shipCreateViewModel);
        _unitOfWork.ShipRepository.Add(ship);
        await _unitOfWork.SaveChangeAsync();
        return ship;
    }

    public async Task<PageList<ShipResponseDto>> GetShips(ShipSearchViewModel shipSearchViewModel)
    {
        var query = _unitOfWork.ShipRepository
            .All()
            .OrderByDescending(e => e.CreatedDate);
        var ships = await query.ToPageListAsync(shipSearchViewModel);
        return _mapper.Map<PageList<ShipResponseDto>>(ships);
    }

    public async Task Update(ShipUpdateViewModel shipUpdateViewModel, Guid id)
    {
        var ship = await _unitOfWork.ShipRepository
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        if (ship is null)
            throw new NotFoundException("Ship does not exist");
        _mapper.Map(shipUpdateViewModel, ship);
        await _unitOfWork.SaveChangeAsync();
    }
}


