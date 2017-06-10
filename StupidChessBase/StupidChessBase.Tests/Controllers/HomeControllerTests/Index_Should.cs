using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Models;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Index_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act & Assert
            controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<IndexViewModels>();
        }
    }
}
