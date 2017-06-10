using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;

namespace StupidChessBase.Tests.Controllers.PlayerControllerTests
{
    [TestFixture]

    public class Constructor_Should
    {

        [Test]
        public void Constructor_ShouldCreateController_WhenNoValuesArePassed()
        {
            // Arrange
            var controller = new PlayerController();

            // Act & Assert
            Assert.IsInstanceOf<PlayerController>(controller);
            Assert.IsInstanceOf<IApplicationDbContext>(controller.db);
            Assert.IsInstanceOf<IClubContext>(controller.liteDb);
        }

        [Test]
        public void Constructor_ShouldCreateController_WhenValuesArePassed()
        {
            // Arrange
            var db = new ApplicationDbContext();
            var liteDb = new ClubContext();
            var controller = new PlayerController(db, liteDb);

            // Act & Assert
            Assert.IsInstanceOf<PlayerController>(controller);
            Assert.AreSame(controller.db, db);
            Assert.AreSame(controller.liteDb, liteDb);
        }
    }
}