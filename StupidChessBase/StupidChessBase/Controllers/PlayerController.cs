using System.Linq;
using System.Web.Mvc;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;

namespace StupidChessBase.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController()
            : base()
        {
        }

        public PlayerController(IApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public ActionResult Ranklist()
        {
            return this.View(new PlayersViewModel()
            {
                PlayersData = this.GetTopPlayers()
            });
        }

        public ActionResult Players()
        {
            var players = this.Db.Players.OrderByDescending(x => x.LastName)
                .Select(x => new PlayerViewModel()
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Rating = x.Rating,
                    Country = x.Country.Name,
                    CountryCode = x.Country.Code.ToLower()
                });

            return this.View(new PlayersViewModel()
            {
                PlayersData = players
            });
        }
    }
}