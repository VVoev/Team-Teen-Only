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
    class DeleteTournamentConfirmed_Should
    {
        [Test]
        public void DeleteTournamentConfirmed_ShouldRedirectWithoutCallingSaveChanges_WhenCalled()
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
        public void DeleteTournamentConfirmed_ShouldRedirectWithCallingSaveChanges_WhenCalled()
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
