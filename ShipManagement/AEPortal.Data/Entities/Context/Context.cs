using Microsoft.EntityFrameworkCore;
using System;

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

        public void SeedRandomPorts()
        {
            var random = new Random();

            // Check if ports already exist
            if (Ports.Any())
            {
                return; // Ports have already been seeded
            }

            // Seed two random ports
            for (int i = 0; i < 5; i++)
            {
                var port = new Port
                {
                    Name = "Port " + (i + 1),
                    Latitude = (decimal)(random.NextDouble() * 180 - 90), // Random latitude between -90 and 90
                    Longitude = (decimal)(random.NextDouble() * 360 - 180) // Random longitude between -180 and 180
                };

                Ports.Add(port);
            }

            SaveChanges();
        }

        public void SeedRandomShips()
        {
            var random = new Random();

            // Check if ships already exist
            if (Ships.Any())
            {
                return; // Ships have already been seeded
            }

            // Seed two random ports
            for (int i = 0; i < 2; i++)
            {
                var ship = new Ship
                {
                    Name = "Ship " + (i + 1),
                    Latitude = (decimal)(random.NextDouble() * 180 - 90), // Random latitude between -90 and 90
                    Longitude = (decimal)(random.NextDouble() * 360 - 180), // Random longitude between -180 and 180
                    Velocity = 20
                };

                Ships.Add(ship);
            }

            SaveChanges();
        }
    }
}
