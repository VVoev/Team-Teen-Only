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
                    Description = x.Description,
                    Id = x.ID
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
        public ActionResult AddTournament(TournamentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var tournament = new Tournament()
                {
                    Title = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Rounds = model.Rounds,
                    Description = model.Description
                };
                this.db.Tournaments.Add(tournament);
                this.db.SaveChanges();

                return this.RedirectToAction("Tournaments");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult EditTournament(int id)
        {
            var tournamentToEdit = this.LoadTournament(id);
            if (tournamentToEdit == null)
            {
                //Todo implement notifications
                return this.RedirectToAction("Tournaments");
            }

            var model = new TournamentInputModel
            {
                Name = tournamentToEdit.Title,
                StartDate = tournamentToEdit.StartDate,
                EndDate = tournamentToEdit.EndDate,
                Rounds = tournamentToEdit.Rounds,
                Description = tournamentToEdit.Description
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTournament(int id, TournamentInputModel model)
        {
            var tournamentToEdit = this.LoadTournament(id);
            if (tournamentToEdit == null)
            {
                //Todo implement notifications
                return this.RedirectToAction("Tournaments");
            }

            if (model != null && this.ModelState.IsValid)
            {
                tournamentToEdit.Title = model.Name;
                tournamentToEdit.StartDate = model.StartDate;
                tournamentToEdit.EndDate = model.EndDate;
                tournamentToEdit.Rounds = model.Rounds;
                tournamentToEdit.Description = model.Description;

                this.db.SaveChanges();
                return this.RedirectToAction("Tournaments");
            }
            return View(model);
        }


        private Tournament LoadTournament(int id)
        {
            //TODO check if is is admin
            var tournamentToEdit = this.db.Tournaments.Where(x => x.ID == id).FirstOrDefault();
            return tournamentToEdit;
        }
    }
}