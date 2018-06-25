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


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Insert2()
        {
            string objname = Request.Form["name"];
            string objphone = Request.Form["phone"];
            string objdiachi = Request.Form["adress"];
            string objmail = Request.Form["email"];
            string objuser = Request.Form["user"];
            string objpass = Request.Form["pass"];
            KHACHHANG temp = new KHACHHANG { MAKH = FuncClass.genNextCode(), TENKH = objname, DIACHI = objdiachi, DIENTHOAI = objphone, EMAIL = objmail, USERNAME = objuser, PASSWORD = objpass };
            db.KHACHHANGs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index", "Welcome");
        }
    }
}