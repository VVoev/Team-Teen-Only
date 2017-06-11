using Moq;
using NUnit.Framework;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace StupidChessBase.Tests.Controllers.BaseControllerTests
{
    [TestFixture]
    public class GetCurrentTournamets_Should
    {
        [Test]
        public void Index_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var mockedDbContext = ContextCreator.CreateMockedApllicationDbContext();
            var mockedLiteDbContext = new Mock<IClubContext>();
            var controller = new BaseController(mockedDbContext.Object, mockedLiteDbContext.Object);

            var validTournament = new TournamentViewModel()
            {
                Id = 3,
                Name = "Valid",
                StartDate = new DateTime(1997, 05, 31),
                EndDate = new DateTime(2020, 04, 30),
                Rounds = 3,
                Counrty = "Bulgariikatadge",
                CounrtyCode = "BG",
                Description = "NeshtoTam"
               
            };
            var invalidTournament = new TournamentViewModel()
            {
                Id = 4,
                Name = "Invalid",
                StartDate = new DateTime(2021, 05, 31),
                EndDate = new DateTime(2025, 04, 30),
                Rounds = 3,
                Counrty = "Bulgariikatadge2",
                CounrtyCode = "BG",
                Description = "NeshtoTam2"

            };

            //Act
            var input = new List<TournamentViewModel>();
            input.Add(validTournament);
            input.Add(invalidTournament);

            var expectedResult = new List<TournamentViewModel>();
            expectedResult.Add(validTournament);

            //Assert

            Assert.AreEqual(expectedResult, controller.GetCurrentTournaments(input));
        }
    }
}
