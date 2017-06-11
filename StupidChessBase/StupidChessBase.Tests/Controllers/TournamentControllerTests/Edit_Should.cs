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
    public class Edit_Should
    {
        [Test]
        public void Edit_ShouldRedirectToTurnament_WhenNullProvided()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(33))
               .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void Edit_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(3))
                .ShouldRenderDefaultView()
                .WithModel<TournamentInputModel>();
        }
    }
}
