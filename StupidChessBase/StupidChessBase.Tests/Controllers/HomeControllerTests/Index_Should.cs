using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Data.Models;
using StupidChessBase.Models;
using StupidChessBase.Tests.Fakes;
using System;
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
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new HomeController(mockedDbContext.Object,mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<IndexViewModels>();
        }
    }
}
