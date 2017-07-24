using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.PlayerControllerTests
{
    [TestFixture]
    public class Ranklist_Should
    {
        [Test]
        public void Ranklist_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new PlayerController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.Ranklist())
                .ShouldRenderDefaultView()
                .WithModel<PlayersViewModel>();
        }
    }
}
