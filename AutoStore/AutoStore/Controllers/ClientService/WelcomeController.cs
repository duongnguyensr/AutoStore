using AutoStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.ClientService
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP));
        }
    }
}