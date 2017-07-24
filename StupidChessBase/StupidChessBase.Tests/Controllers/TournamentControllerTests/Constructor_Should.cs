using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;

namespace StupidChessBase.Tests.Controllers.TournamentControllerTests
{
    [TestFixture]

    public class Constructor_Should
    {

        [Test]
        public void Constructor_ShouldCreateController_WhenNoValuesArePassed()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            Assert.IsInstanceOf<TournamentController>(controller);
            Assert.IsInstanceOf<IApplicationDbContext>(controller.Db);
        }

        [Test]
        public void Constructor_ShouldCreateController_WhenValuesArePassed()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            Assert.IsInstanceOf<TournamentController>(controller);
            Assert.AreSame(controller.Db, mockedDbContext.Object);
        }
    }
}