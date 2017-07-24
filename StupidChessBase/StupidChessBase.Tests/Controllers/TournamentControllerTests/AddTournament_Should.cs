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
    class AddTournament_Should
    {
        [Test]
        public void AddTournament_ShouldReturnTournamentInputModel_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.AddTournament())
                .ShouldRenderDefaultView()
                .WithModel<TournamentInputModel>();
        }

        [Test]
        public void AddTournament_ShouldReturn_WhenNullIsPassed()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var controller = new TournamentController(mockedDbContext.Object);

            // Act & Assert
            controller.WithCallTo(x => x.AddTournament(null))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void AddTournament_ShouldRedirect_WhenTournamentIsPassed()
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
            controller.WithCallTo(x => x.AddTournament(model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }
    }
}
