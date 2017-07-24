using Moq;
using NUnit.Framework;
using Rotativa;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.TournamentControllerTests
{
    [TestFixture]
    class Report_Should
    {
        [Test]
        public void Report_ShouldRedirectToTurnament_WhenNullProvided()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.ReportTournament(33))
               .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void Report_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            Assert.IsInstanceOf<ViewAsPdf>(controller.ReportTournament(3));

        }
    }
}
