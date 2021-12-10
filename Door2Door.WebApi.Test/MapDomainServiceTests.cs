using Door2Door.WebApi.DomainServices;
using Door2Door.WebApi.InfrastructureServices;
using Door2Door.WebApi.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Door2Door.WebApi.Test
{
    public class MapDomainServiceTests
    {
        private Mock<IDatabaseInfrastructureService> _databaseInfrastructureServiceMock;
        private Mock<ILogger<MapDomainService>> _loggerMock;
        private MapDomainService _sut;

        [SetUp]
        public void Setup()
        {
            _databaseInfrastructureServiceMock = new Mock<IDatabaseInfrastructureService>();
            _loggerMock = new Mock<ILogger<MapDomainService>>();

            _sut = new MapDomainService(_databaseInfrastructureServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetMapCatagoriesAndRoomsAsync_ShouldGetCatagoriesAndRooms()
        {
            // Arrange
            string location = "Zbc";

            List<Room> rooms = new()
            {
                new Room() { Name = "B08", TypeName = "Klasselokale" },
                new Room() { Name = "B14", TypeName = "Klasselokale" },
                new Room() { Name = "Depot", TypeName = "Andet" }
            };

            _databaseInfrastructureServiceMock
                .Setup(x => x.GetMapCatagoriesAndRoomsAsync(location))
                .ReturnsAsync(rooms);

            // Act
            List<CatagoriesWithRooms> result = await _sut.GetMapCatagoriesAndRoomsAsync(location);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[1].Name.Should().Match("Andet");
        }
    }
}
