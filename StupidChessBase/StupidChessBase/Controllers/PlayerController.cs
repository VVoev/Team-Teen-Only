using StupidChessBase.Data;
using StupidChessBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Wins = x.Wins,
                Loses = x.Loses,
                Draws = x.Draws
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
                    FullName = x.FirstName + x.LastName,
                    Rating = x.Rating,
                    Country = x.Country.Name
            });

            return View(new PlayersViewModel()
            {
                PlayersData = players
            });
        }
    }
}