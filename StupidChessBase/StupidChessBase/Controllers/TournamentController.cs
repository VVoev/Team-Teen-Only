using StupidChessBase.Models;
using System.Linq;
using System.Web.Mvc;

namespace StupidChessBase.Controllers
{
    public class TournamentController : BaseController
    {
        public ActionResult Tournaments()
        {
            var tournaments = this.db.Tournaments.OrderByDescending(x => x.Date).Select(x => new TournamentViewModel()
            {
                Name = x.Title,
                Date = x.Date,
                Rounds = x.Rounds
            });

            return View(new TournamentsViewModel()
            {
                TournamentsData = tournaments
            });
        }
        public ActionResult AddTournament()
        {
            return View();
        }
    }
}