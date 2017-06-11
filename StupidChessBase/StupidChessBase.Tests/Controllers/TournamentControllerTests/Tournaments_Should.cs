using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Data.Models;
using StupidChessBase.Models;
using StupidChessBase.Tests.Fakes;
using System;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.TournamentControllerTests
{
    [TestFixture]
    public class Tournaments_Should
    {
        [Test]
        public void Tournament_ShouldReturnUpcomingPassedTournamentsViewModel_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new TournamentController(mockedDbContext.Object, mockedLiteDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.Tournaments())
                .ShouldRenderDefaultView()
                .WithModel<UpcomingPassedTournamentsViewModel>();
        }
    }
}
