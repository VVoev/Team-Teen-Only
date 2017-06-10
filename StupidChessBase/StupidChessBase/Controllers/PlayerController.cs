using System.Linq;
using System.Web.Mvc;
using StupidChessBase.Models;
using StupidChessBase.Data.Contexts;

namespace StupidChessBase.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController() : base()
        { }
        public PlayerController(IApplicationDbContext applicationDbContext, IClubContext clubContext) : base(applicationDbContext, clubContext)
        { }
        public ActionResult Ranklist()
        {
            var players = this.db.Players.OrderByDescending(x => x.Rating).Select(x => new PlayerViewModel()
            {
                FullName = x.FirstName + " " + x.LastName,
                Rating = x.Rating,
                Country = x.Country.Name,
                CountryCode = x.Country.Code.ToLower()
            });

            return View(new PlayersViewModel()
            {
                PlayersData = players
            });
        }

        public ActionResult Players()
        {
            var players = this.db.Players.OrderByDescending(x => x.LastName)
                .Select(x => new PlayerViewModel()
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Rating = x.Rating,
                    Country = x.Country.Name,
                    CountryCode = x.Country.Code.ToLower()
                });

            return View(new PlayersViewModel()
            {
                PlayersData = players
            });
        }
    }
}