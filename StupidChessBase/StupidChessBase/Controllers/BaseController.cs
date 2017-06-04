using System.Web.Mvc;
using StupidChessBase.Data;

namespace StupidChessBase.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db  = new ApplicationDbContext();
    }
}