using NUnit.Framework;
using StupidChessBase.Controllers;
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
            var controller = new PlayerController();

            // Act & Assert
            controller.WithCallTo(x => x.Ranklist())
                .ShouldRenderDefaultView()
                .WithModel<PlayersViewModel>();
        }
    }
}
