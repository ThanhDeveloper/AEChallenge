using AEPortal.Bussiness.Facades;
using AEPortal.Bussiness.Services;
using AEPortal.Bussiness.UnitOfWorks;
using AEPortal.Bussiness.ViewModel;
using AEPortal.Common.GenericRepository;
using AEPortal.Data.Entities;
using AutoMapper;
using Moq;

namespace AEPortal.UnitTesting
{
    public class ShipTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Create_ValidInput_CreatesNewShip()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockShipRepository = new Mock<IGenericRepository<Ship>>();
            mockUnitOfWork.Setup(uow => uow.ShipRepository).Returns(mockShipRepository.Object);
            var shipService = new ShipService(mockMapper.Object, mockUnitOfWork.Object);
            var shipCreateViewModel = new ShipCreateViewModel {
                Name = "ShipName",
                Latitude = 12,
                Longitude = 12,
                Velocity = 32
            };

            // Act
            await shipService.Create(shipCreateViewModel);

            // Assert
            mockShipRepository.Verify(repo => repo.Add(It.IsAny<Ship>()), Times.Once);
        }

        //The test method asserts that the calculated distance to the closest port is equal to the expected value and that the closest port is equal to the expected port.
        [Test]
        public void CalculateDistance_ValidInput_ReturnsCorrectDistance()
        {
            // Arrange
            double expectedDistance = 2031.8573373239258;
            var ship = new Ship() { Id = Guid.NewGuid(), Latitude = 10, Longitude = 20, Velocity = 30 };
            var ports = new List<Port>
            {
                new Port { Id = Guid.NewGuid(), Name = "Port A", Latitude = 2.0m, Longitude = 2.0m },
                new Port { Id = Guid.NewGuid(), Name = "Port B", Latitude = 3.0m, Longitude = 3.0m }
            };

            // Act
            Port? closestPort = null;
            double minDistance = double.MaxValue;
            foreach (var port in ports)
            {
                // Calculate the distance between the ship and the port
                double distance = ShipFacade.CalculateDistance((double)ship.Latitude, (double)ship.Longitude, (double)port.Latitude, (double)port.Longitude);
                Console.WriteLine($"Distance to {port.Name}: {distance}");
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPort = port;
                }
            }

            // Calculate the estimated arrival time to the closest port
            double estimatedArrivalTime = minDistance / ship.Velocity;
            // Assert
            Assert.That(minDistance, Is.EqualTo(expectedDistance));
            Assert.That(closestPort, Is.EqualTo(ports[1]));
        }

    }
}