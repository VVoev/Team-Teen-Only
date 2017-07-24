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
    public class Delete_Should
    {
        [Test]
        public void Delete_ShouldRedirectToTurnament_WhenNullProvided()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.DeleteTournament(33))
               .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void Delete_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.DeleteTournament(3))
                .ShouldRenderDefaultView();
        }
    }
}
