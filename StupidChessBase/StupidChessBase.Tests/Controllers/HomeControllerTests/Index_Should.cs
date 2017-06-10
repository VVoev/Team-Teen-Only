using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Models;
using System.Web.Mvc;

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
            Assert.IsInstanceOf<ViewResult>(controller.Index());
        }
        [Test]
        public void Index_ShouldReturnIndexViewModelsTypeModel_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;


            // Assert
            Assert.IsInstanceOf<IndexViewModels>(result.Model);
        }
    }
}
