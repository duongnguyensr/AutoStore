using AutoStore.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers
{
    [SessionTimeout]
    public class ChiTietPhieuNhapController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.CHITIETPHIEUNHAPs.ToList().OrderBy(a => a.MASP));
        }

        public ActionResult getDataPHIEUNHAP()
        {
            var maPN = db.PHIEUNHAPs.ToList().OrderBy(a => a.TENPN);
            return View(maPN);
        }

        public ActionResult getDataSANPHAM()
        {
            var maSP = db.SANPHAMs.ToList().OrderBy(a => a.TENSP);
            return View(maSP);
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objmapn = Request.Form["tenpn"];
            string objmasp = Request.Form["tensp"];
            int objsoluong = Int32.Parse(Request.Form["soluong"]);
            double objdongia = double.Parse(Request.Form["dongia"]);
            CHITIETPHIEUNHAP temp = new CHITIETPHIEUNHAP { MAPN = objmapn, MASP = objmasp, SOLUONG = objsoluong, DONGIANHAP = objdongia };
            db.CHITIETPHIEUNHAPs.Add(temp);
            db.SaveChanges();
            Session["tab"] = "chitiet";
            return RedirectToAction("Index1", "PhieuNhap");
        }

        public ActionResult Delete(string ID, string IDSP)
        {
            var temp = new CHITIETPHIEUNHAP { MAPN = ID, MASP = IDSP };
            db.CHITIETPHIEUNHAPs.Attach(temp);
            db.CHITIETPHIEUNHAPs.Remove(temp);
            db.SaveChanges();
            Session["tab"] = "chitiet";
            return RedirectToAction("Index1", "PhieuNhap");
        }

        [HttpPost]
        public ActionResult update(string id, string idsp)
        {
            var result = db.CHITIETPHIEUNHAPs.SingleOrDefault(a => a.MAPN == id && a.MASP == idsp);
            if (result != null)
            {
                //result.MAPN = Request.Form["tenpn"];
                //result.MASP = Request.Form["tensp"];
                result.SOLUONG = Int32.Parse(Request.Form["soluong"]);
                result.DONGIANHAP = double.Parse(Request.Form["dongia"]);
                db.SaveChanges();
            }
            Session["tab"] = "chitiet";

            return RedirectToAction("Index1", "PhieuNhap");
        }
    }
}