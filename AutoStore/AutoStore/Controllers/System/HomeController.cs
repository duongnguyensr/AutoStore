using System.Web.Mvc;

namespace AutoStore.Controllers
{
    [SessionTimeout]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}