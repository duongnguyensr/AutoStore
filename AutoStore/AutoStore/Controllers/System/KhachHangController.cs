using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        DBConnection db = new DBConnection();
        public ActionResult Index()
        {

            return View(db.KHACHHANGs.ToList().OrderBy(a=>a.TENKH));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objname = Request.Form["name"];
            string objphone = Request.Form["phone"];
            string objdiachi = Request.Form["adress"];
            string objmail = Request.Form["email"];
            KHACHHANG temp = new KHACHHANG { MAKH = FuncClass.genNextCode(), TENKH = objname, DIACHI = objdiachi, DIENTHOAI = objphone, EMAIL = objmail };
            db.KHACHHANGs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID)
        {
            var temp = new KHACHHANG { MAKH = ID };
            db.KHACHHANGs.Attach(temp);
            db.KHACHHANGs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.KHACHHANGs.SingleOrDefault(a => a.MAKH == id);
            if (result != null)
            {
                result.TENKH = Request.Form["name"];
                result.EMAIL = Request.Form["email"];
                result.DIACHI = Request.Form["adress"];
                result.DIENTHOAI = Request.Form["phone"];
                db.SaveChanges();
            }

          
            return RedirectToAction("Index");
        }
    }
}