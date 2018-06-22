using AutoStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.ClientService
{
    public class DetailController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index(string idsp)
        {
            return View(db.SANPHAMs.Where(a => a.MASP == idsp).FirstOrDefault());
        }
    }
}