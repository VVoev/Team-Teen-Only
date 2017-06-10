using NUnit.Framework;
using StupidChessBase.Controllers;
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
            var controller = new PlayerController();

            // Act & Assert
            controller.WithCallTo(x => x.Players())
                .ShouldRenderDefaultView()
                .WithModel<PlayersViewModel>();
        }
    }
}
