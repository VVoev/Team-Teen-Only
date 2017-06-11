using Moq;
using StupidChessBase.Controllers;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Data.Models;
using StupidChessBase.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Tests.Controllers
{
    public class ContextCreator
    {
        public static Mock<IApplicationDbContext> CreateMockedApllicationDbContext()
        {
            var mockedDbContext = new Mock<IApplicationDbContext>();

            mockedDbContext.Setup(x => x.Players).Returns(new FakeDbSet<Player>()
            {
                new Player
                {
                    ID = 1,
                    FirstName = "Goshko",
                    LastName = "Ivanov",
                    Country = new Country
                        {
                            ID = 35,
                            Name = "Bulgariikata",
                            Code = "BG"
                        }
                }
            });

            mockedDbContext.Setup(x => x.Tournaments).Returns(new FakeDbSet<Tournament>()
            {
                new Tournament
                {
                    ID = 3,
                    Title = "Nai-gotiniq",
                    StartDate = new DateTime(1992,05,12),
                    EndDate = new DateTime(2020,05,12),
                    Rounds = 5,
                    Country = new Country
                        {
                            ID = 36,
                            Name = "Bulgariikata2",
                            Code = "BG"
                        },
                    Description = "Mnogo gotina durjava"
                }
            });

            mockedDbContext.Setup(x => x.Countries).Returns(new FakeDbSet<Country>()
            {
                new Country
                        {
                            ID = 36,
                            Name = "Bulgariikata2",
                            Code = "BG"
                        }
            });

            mockedDbContext.Setup(x => x.SaveChanges()).Verifiable();

            return mockedDbContext;
        }
    }
}
