using AEPortal.Common.GenericRepository;
using AEPortal.Common.UnitOfWork;
using AEPortal.Data.Entities;
using AEPortal.Data.Entities.Context;

namespace AEPortal.Bussiness.UnitOfWorks
{
    public interface IUnitOfWork : IUnitOfWorkBase<Context>
    {
        IGenericRepository<Ship> ShipRepository { get; }
    }

    public class UnitOfWork : UnitOfWorkBase<Context>, IUnitOfWork
    {

        public UnitOfWork(Context context, IGenericRepository<Ship> shipRepository) : base(context)
        {
            ShipRepository = shipRepository;
        }

        public IGenericRepository<Ship> ShipRepository { get; }
    }
}
