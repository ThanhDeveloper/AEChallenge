using AEPortal.Bussiness.ResponseModel;
using AEPortal.Bussiness.UnitOfWorks;
using AEPortal.Common.Extentions;
using AutoMapper;

namespace AEPortal.Bussiness.Services;
public interface IPortService
{
    Task<ClosestPortResponse> GetClosestPort(Guid shipId);
}

public class PortService : IPortService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PortService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ClosestPortResponse> GetClosestPort(Guid shipId)
    {
        // Get the ship with the given id
        var ship = await _unitOfWork.ShipRepository.GetByIdAsync(shipId);

        // Calculate the distance between the ship and each port
        var portDistances = _unitOfWork.PortRepository
                    .All()
                    .Select(port => new
                    {
                        Port = port,
                        Distance = CalculateDistance(ship.Latitude, ship.Longitude, port.Latitude, port.Longitude)
                    });
        // Find the closest port
        var closestPort = portDistances.OrderBy(pd => pd.Distance).First();

        // Calculate the estimated arrival time
        var estimatedArrivalTime = DateTime.Now.AddHours(closestPort.Distance / ship.Velocity);

        // Return the response
        return new ClosestPortResponse
        {
            PortName = closestPort.Port.Name,
            EstimatedArrivalTime = estimatedArrivalTime
        };
    }

    private double CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
    {
        return 0;
    }
}


