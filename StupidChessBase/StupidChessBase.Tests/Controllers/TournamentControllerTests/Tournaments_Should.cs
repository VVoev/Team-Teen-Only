using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Models;
using System;
using System.Linq;
using System.Web.Mvc;
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
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.Tournaments())
                .ShouldRenderDefaultView()
                .WithModel<UpcomingPassedTournamentsViewModel>();
        }
        [Test]
        public void AddTournament_ShouldReturnTournamentInputModel_WhenCalled()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.AddTournament())
                .ShouldRenderDefaultView()
                .WithModel<TournamentInputModel>();
        }

        [Test]
        public void AddTournament_ShouldReturn_WhenNullIsPassed()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.AddTournament(null))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void AddTournament_ShouldRedirect_WhenTournamentIsPassed()
        {
            // Arrange
            var controller = new TournamentController();

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
            controller.WithCallTo(x => x.AddTournament(model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }
    }
}
