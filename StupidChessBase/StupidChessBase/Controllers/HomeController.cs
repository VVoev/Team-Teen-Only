using StupidChessBase.Models;
using System.Web.Mvc;

namespace StupidChessBase.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(new IndexViewModels()
            {
                Players = this.GetTopPlayers(),
                CurrentTournaments = this.GetCurrentTournaments(this.GetAllTournaments())
            });    
        }
    }
}