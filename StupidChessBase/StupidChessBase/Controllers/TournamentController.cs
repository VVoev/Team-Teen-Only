﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Rotativa;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Data.Models;
using StupidChessBase.Models;

namespace StupidChessBase.Controllers
{
    public class TournamentController : BaseController
    {
        public TournamentController()
            : base()
        {
        }

        public TournamentController(IApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public ActionResult Tournaments()
        {
            var tournaments = GetAllTournaments();

            var upcomingTournaments = tournaments.Where(t => t.StartDate > DateTime.Now);
            var currentTournaments = GetCurrentTournaments(tournaments);
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
            var model = new TournamentInputModel() { Countries = new List<SelectListItem>() };
            model.Countries.Add(new SelectListItem() { Text = "Select country ...", Disabled = true, Selected = true });

            this.FillCountriesInSelectListFromDatabase(model);

            return this.View(model);
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
                    CountryID = this.Db.Countries.Single(c => c.Name == model.Country).ID,
                    Description = model.Description
                };

                this.Db.Tournaments.Add(tournament);
                this.Db.SaveChanges();

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
                Country = tournamentToEdit.Country.Name,
                Description = tournamentToEdit.Description,
                Countries = new List<SelectListItem>()
            };

            this.FillCountriesInSelectListFromDatabase(model);

            return this.View(model);
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

            if (model != null)
            {
                tournamentToEdit.Title = model.Name;
                tournamentToEdit.StartDate = model.StartDate;
                tournamentToEdit.EndDate = model.EndDate;
                tournamentToEdit.Rounds = model.Rounds;
                tournamentToEdit.CountryID = this.Db.Countries.Single(c => c.Name == model.Country).ID;
                tournamentToEdit.Description = model.Description;

                this.Db.SaveChanges();
                return this.RedirectToAction("Tournaments");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult DeleteTournament(int id)
        {
            var tournamentToDelete = this.LoadTournament(id);
            if (tournamentToDelete == null)
            {
                //Todo implement notifications
                return this.RedirectToAction("Tournaments");
            }

            var model = new TournamentInputModel
            {
                Name = tournamentToDelete.Title,
                StartDate = tournamentToDelete.StartDate,
                EndDate = tournamentToDelete.EndDate,
                Rounds = tournamentToDelete.Rounds,
                Country = tournamentToDelete.Country.Name,
                Description = tournamentToDelete.Description,
            };

            return this.View(model);
        }

        [HttpPost, ActionName("DeleteTournament")]
        public ActionResult DeleteTournamentConfirmed(int id)
        {
            var tournamentToDelete = this.LoadTournament(id);
            if (tournamentToDelete == null)
            {
                //Todo implement notifications
                return this.RedirectToAction("Tournaments");
            }

            this.Db.Tournaments.Remove(tournamentToDelete);
            this.Db.SaveChanges();

            return this.RedirectToAction("Tournaments");
        }

        [HttpGet]
        public ActionResult ReportTournament(int id)
        {
            var tournamentToReport = this.LoadTournament(id);
            if (tournamentToReport == null)
            {
                return this.RedirectToAction("Tournaments");
            }

            var model = new TournamentInputModel
            {
                Name = tournamentToReport.Title,
                StartDate = tournamentToReport.StartDate,
                EndDate = tournamentToReport.EndDate,
                Rounds = tournamentToReport.Rounds,
                Country = tournamentToReport.Country.Name,
                Description = tournamentToReport.Description,
            };

            return new ViewAsPdf(model);
        }

        private Tournament LoadTournament(int id)
        {
            //TODO check if is is admin
            var tournamentToEdit = this.Db.Tournaments.Where(x => x.ID == id).FirstOrDefault();
            return tournamentToEdit;
        }

        private void FillCountriesInSelectListFromDatabase(TournamentInputModel model)
        {
            foreach (var country in Db.Countries)
            {
                model.Countries.Add(new SelectListItem()
                {
                    Text = country.Name,
                });
            }
        }
    }
}