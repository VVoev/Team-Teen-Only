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

        [Test]
        public void EditTournament_ShouldReturn_WhenValidIdIsPassed()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(2))
                .ShouldRenderDefaultView()
                .WithModel<TournamentInputModel>();
        }

        [Test]
        public void EditTournament_ShouldRedirect_WhenNullIsPassed()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(0))
                 .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void EditTournamentWithModel_ShouldRedirect_WhenNullIsPassed()
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
            controller.WithCallTo(x => x.EditTournament(0,model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void EditTournamentWithModel_ShouldRedirect_WhenValidDataIsPassed()
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
            controller.WithCallTo(x => x.EditTournament(2, model))
                 .ShouldRedirectTo(x => x.Tournaments);
        }

        [Test]
        public void EditTournamentWithModel_ShouldReturn_WhenModelIsNull()
        {
            // Arrange
            var controller = new TournamentController();

            // Act & Assert
            controller.WithCallTo(x => x.EditTournament(2, null))
                   .ShouldRenderDefaultView();
        }
    }
}
