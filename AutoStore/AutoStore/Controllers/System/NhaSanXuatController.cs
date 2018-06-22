using AutoStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class NhaSanXuatController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.NHASANXUATs.ToList().OrderBy(a => a.TENNSX));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objname = Request.Form["name"];
            string objphone = Request.Form["phone"];
            string objmota = Request.Form["mota"];
            NHASANXUAT temp = new NHASANXUAT { MANSX = FuncClass.genNextCode(), TENNSX = objname, DIENTHOAI = objphone, MOTA = objmota };
            db.NHASANXUATs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new NHASANXUAT { MANSX = ID };
            db.NHASANXUATs.Attach(temp);
            db.NHASANXUATs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.NHASANXUATs.SingleOrDefault(a => a.MANSX == id);
            if (result != null)
            {
                result.TENNSX = Request.Form["name"];
                result.MOTA = Request.Form["mota"];
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