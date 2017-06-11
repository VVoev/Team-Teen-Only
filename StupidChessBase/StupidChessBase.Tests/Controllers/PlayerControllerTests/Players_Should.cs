using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.PlayerControllerTests
{
    [TestFixture]
    public class Players_Should
    {
        [Test]
        public void Players_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new PlayerController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.Players())
                .ShouldRenderDefaultView()
                .WithModel<PlayersViewModel>();
        }
    }
}
