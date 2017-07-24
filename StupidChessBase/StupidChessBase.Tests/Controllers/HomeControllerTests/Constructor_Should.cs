using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data;
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
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateController_WhenNoValuesArePassed()
        {
            // Arrange
            var controller = new HomeController();

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(controller);
            Assert.IsInstanceOf<IApplicationDbContext>(controller.Db);
        }

        [Test]
        public void Constructor_ShouldCreateController_WhenValuesArePassed()
        {
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new HomeController(mockedDbContext.Object);

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(controller);
            Assert.AreSame(controller.Db, mockedDbContext.Object);
        }
    }
}
