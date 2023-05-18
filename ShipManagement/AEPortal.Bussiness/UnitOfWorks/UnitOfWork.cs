using AEPortal.Common.GenericRepository;
using AEPortal.Common.UnitOfWork;
using AEPortal.Data.Entities;
using AEPortal.Data.Entities.Context;

namespace AEPortal.Bussiness.UnitOfWorks
{
    public interface IUnitOfWork : IUnitOfWorkBase<Context>
    {
        IGenericRepository<Ship> ShipRepository { get; }
        IGenericRepository<Port> PortRepository { get; }
    }

    public class UnitOfWork : UnitOfWorkBase<Context>, IUnitOfWork
    {

        public UnitOfWork(Context context, IGenericRepository<Ship> shipRepository, IGenericRepository<Port> portRepository) : base(context)
        {
            ShipRepository = shipRepository;
            PortRepository = portRepository;
        }

        public IGenericRepository<Ship> ShipRepository { get; }
        public IGenericRepository<Port> PortRepository { get; }
    }
}
