using System;
using System.Linq;
using System.Web.Mvc;
using StupidChessBase.Models;
using StupidChessBase.Data.Models;

namespace StupidChessBase.Controllers
{
    public class TournamentController : BaseController
    {

        public ActionResult Tournaments()
        {
            var tournaments = this.db.Tournaments
                .OrderByDescending(x => x.StartDate)
                .Select(x => new TournamentViewModel()
            {
                Name = x.Title,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Rounds = x.Rounds,
                Description = x.Description
            });

            var upcomingTournaments = tournaments.Where(t => t.StartDate > DateTime.Now);
            var currentTournaments = tournaments.Where(t => t.StartDate < DateTime.Now && t.EndDate > DateTime.Now);
            var passedTournaments = tournaments.Where(t => t.EndDate < DateTime.Now);

            return this.View(new UpcomingPassedTournamentsViewModel()
            {
                UpcomingTournaments = upcomingTournaments,
                CurrentTournaments = currentTournaments,
                PassedTournaments = passedTournaments
            });
        }

        [HttpGet]
        public ActionResult AddTournament()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTournament(AddTournamentModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var tournament = new Tournament(10, model.Name, model.StartDate, model.EndDate, model.Rounds, model.Description);
                this.db.Tournaments.Add(tournament);
                this.db.SaveChanges();

                return this.RedirectToAction("Tournaments");
            }

            return this.View(model);
        }
    }
}