using Moq;
using NUnit.Framework;
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
        public void Tournament_ShouldRedirectToTurnament_WhenNullProvided()
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
        public void Tournament_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(3))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Tournament_ShouldRedirectWithoutCallingSaveChanges_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.DeleteTournamentConfirmed(33))
               .ShouldRedirectTo(x => x.Tournaments);


            mockedDbContext.Verify(x => x.SaveChanges(), Times.Exactly(0));
        }

        [Test]
        public void Tournament_ShouldRedirectWithCallingSaveChanges_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.DeleteTournamentConfirmed(3))
               .ShouldRedirectTo(x => x.Tournaments);


            mockedDbContext.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }
    }
}
