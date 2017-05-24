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
        public ActionResult Players()
        {
            var players = this.db.Players.OrderBy(x => x.Rating).Select(x => new PlayerViewModel()
            {
                FullName = x.FirstName + " " + x.LastName,
                Rating = x.Rating,
                Wins = x.Wins,
                Loses = x.Loses,
                Draws = x.Draws
            });

            return View(new PlayersViewModel()
            {
                PlayersData = players
            });
        }
    }
}