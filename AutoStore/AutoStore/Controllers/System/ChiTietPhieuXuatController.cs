using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class ChiTietPhieuXuatController : Controller
    {
        DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.CHITIETPHIEUXUATs.ToList().OrderBy(a => a.MASP));
        }

        public ActionResult getDataPHIEUXUAT()
        {
            var maPX = db.PHIEUXUATs.ToList().OrderBy(a => a.TENPX);
            return View(maPX);
        }

        public ActionResult getDataSANPHAM()
        {
            
            return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objmapn = Request.Form["tenpx2"];
            string objmasp = Request.Form["tensp"];
            int objsoluong = Int32.Parse(Request.Form["soluong"]);
            double objdongia = double.Parse(Request.Form["dongia"]);
            CHITIETPHIEUXUAT temp = new CHITIETPHIEUXUAT { MAPX = objmapn, MASP = objmasp, SOLUONG = objsoluong, DONGIAXUAT = objdongia };
            db.CHITIETPHIEUXUATs.Add(temp);
            db.SaveChanges();
            Session["tab1"] = "chitiet";
            return RedirectToAction("Index1","PhieuXuat");
        }


        public ActionResult Delete(string ID, string IDSP)
        {
            var temp = new CHITIETPHIEUXUAT { MAPX = ID, MASP = IDSP };
            db.CHITIETPHIEUXUATs.Attach(temp);
            db.CHITIETPHIEUXUATs.Remove(temp);
            db.SaveChanges();
            Session["tab1"] = "chitiet";
            return RedirectToAction("Index1","PhieuXuat");
        }

        [HttpPost]
        public ActionResult update(string id, string idsp)
        {
            var result = db.CHITIETPHIEUXUATs.SingleOrDefault(a => a.MAPX == id && a.MASP == idsp);
            if (result != null)
            {
                result.SOLUONG = Int32.Parse(Request.Form["soluong"]);
                result.DONGIAXUAT = double.Parse(Request.Form["dongia"]);
                db.SaveChanges();
            }
            Session["tab1"] = "chitiet";
            return RedirectToAction("Index1","PhieuXuat");
        }
    }
}