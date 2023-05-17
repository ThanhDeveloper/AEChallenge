using Microsoft.EntityFrameworkCore;

namespace AEPortal.Common.UnitOfWork
{
    public interface IUnitOfWorkBase<TContext> : IDisposable where TContext : DbContext
    {
        Task SaveChangeAsync();
    }

    public class UnitOfWorkBase<TContext> : IUnitOfWorkBase<TContext> where TContext : DbContext
    {
        private TContext _context;

        public UnitOfWorkBase(TContext context)
        {
            _context = context;
        }

        public Task SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
