using System.Linq;
using System.Web.Mvc;

using StupidChessBase.Models;

namespace StupidChessBase.Controllers
{
    public class PlayerController : BaseController
    {
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