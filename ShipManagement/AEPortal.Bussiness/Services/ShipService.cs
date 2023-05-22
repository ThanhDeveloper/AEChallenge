using AEPortal.Bussiness.Facades;
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
    Task<ShipClosestPortResponse> GetClosestPort(Guid id);
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

    public async Task<ShipClosestPortResponse> GetClosestPort(Guid shipId)
    {
        // Get the ship with the given id
        var ship = await _unitOfWork.ShipRepository.GetByIdAsync(shipId);

        if (ship is null)
            throw new NotFoundException("Ship does not exist");

        // Get all ports
        var ports = await _unitOfWork.PortRepository.All().ToListAsync();

        // Find the closest port to the ship
        Port closestPort = null;
        double minDistance = double.MaxValue;
        foreach (var port in ports)
        {
            // Calculate the distance between the ship and the port
            double distance = ShipFacade.CalculateDistance((double)ship.Latitude, (double)ship.Longitude, (double)port.Latitude, (double)port.Longitude);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPort = port;
            }
        }

        // Calculate the estimated arrival time to the closest port
        double estimatedArrivalTime = minDistance / ship.Velocity;

        // Create and return the response
        var response = new ShipClosestPortResponse
        {
            ShipId = shipId,
            PortId = closestPort.Id,
            PortName = closestPort.Name,
            EstimatedArrivalTime = estimatedArrivalTime
        };
        return response;
    }

    
}


