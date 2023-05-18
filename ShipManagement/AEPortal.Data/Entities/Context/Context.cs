using Microsoft.EntityFrameworkCore;

namespace AEPortal.Data.Entities.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }

    }
}
