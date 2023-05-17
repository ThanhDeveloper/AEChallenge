using AEPortal.Bussiness.UnitOfWorks;
using AutoMapper;

namespace AEPortal.Bussiness.Services;
public interface IShipService
{
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

}


