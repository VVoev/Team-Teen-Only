using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using System;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.TournamentControllerTests
{
    [TestFixture]
    public class EditWIthModel_Should
    {
        [Test]
        public void EditTournamentWithModel_ShouldRedirect_WhenNullIsPassed()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);


            var model = new TournamentInputModel()
            {
                Name = "testTest",
                StartDate = new DateTime(2015, 1, 18),
                EndDate = new DateTime(2020, 1, 18),
                Rounds = 3,
                Country = "Bulgaria",
                Description = "TestTestTest"
            };
            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(0, model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void EditTournamentWithModel_ShouldRedirect_WhenValidDataIsPassed()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            var model = new TournamentInputModel()
            {
                Name = "testTest",
                StartDate = new DateTime(2015, 1, 18),
                EndDate = new DateTime(2020, 1, 18),
                Rounds = 3,
                Country = "Bulgariikata2",
                Description = "TestTestTest"
            };
            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(3, model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void EditTournamentWithModel_ShouldReturn_WhenModelIsNull()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(3, null))
                   .ShouldRenderDefaultView();
        }
    }
}
