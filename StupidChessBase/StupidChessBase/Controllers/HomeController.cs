using System.Web.Mvc;

namespace StupidChessBase.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}