using AutoStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class NhaCungCapController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.NHACUNGCAPs.ToList().OrderBy(a => a.TENNCC));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objname = Request.Form["name"];
            string objphone = Request.Form["phone"];
            string objdiachi = Request.Form["adress"];
            string objmail = Request.Form["email"];
            NHACUNGCAP temp = new NHACUNGCAP { MANCC = FuncClass.genNextCode(), TENNCC = objname, DIACHI = objdiachi, DIENTHOAI = objphone, EMAIL = objmail };
            db.NHACUNGCAPs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new NHACUNGCAP { MANCC = ID };
            db.NHACUNGCAPs.Attach(temp);
            db.NHACUNGCAPs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.NHACUNGCAPs.SingleOrDefault(a => a.MANCC == id);
            if (result != null)
            {
                result.TENNCC = Request.Form["name"];
                result.EMAIL = Request.Form["email"];
                result.DIACHI = Request.Form["adress"];
                result.DIENTHOAI = Request.Form["phone"];
                db.SaveChanges();
            }

            //if(id=="")
            //{
            //    KHACHHANG temp = new KHACHHANG { MAKH = FuncClass.genNextCode(), TENKH = ten, DIACHI = adress, DIENTHOAI = phone, EMAIL = email };
            //    db.KHACHHANGs.Add(temp);
            //    db.SaveChanges();
            //}
            return RedirectToAction("Index");
        }
    }
}