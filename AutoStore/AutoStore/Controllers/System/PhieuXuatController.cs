using AutoStore.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class PhieuXuatController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.PHIEUXUATs.ToList().OrderBy(a => a.MANV));
        }

        public ActionResult Index1()
        {
            return View(db.PHIEUXUATs.ToList().OrderBy(a => a.MANV));
        }

        public ActionResult getDataNHANVIEN()
        {
            var maNV = db.NHANVIENs.ToList().OrderBy(a => a.TENNV);
            return View(maNV);
        }

        public ActionResult getDataKHACHHANG()
        {
            var maKH = db.KHACHHANGs.ToList().OrderBy(a => a.TENKH);
            return View(maKH);
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objmanv = Request.Form["manv"];

            string objtenpn = Request.Form["tenpx"];
            DateTime objngaynhap = DateTime.ParseExact(Request.Form["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string objmakh = Request.Form["makh"];
            PHIEUXUAT temp = new PHIEUXUAT { MAPX = FuncClass.genNextCode(), TENPX = objtenpn, MANV = objmanv, NGAYXUAT = objngaynhap, MAKH = objmakh };
            db.PHIEUXUATs.Add(temp);
            db.SaveChanges();
            Session.Remove("tab1");
            return RedirectToAction("Index1");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new PHIEUXUAT { MAPX = ID };
            db.PHIEUXUATs.Attach(temp);
            db.PHIEUXUATs.Remove(temp);
            db.SaveChanges();
            Session.Remove("tab1");
            return RedirectToAction("Index1");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.PHIEUXUATs.SingleOrDefault(a => a.MAPX == id);
            if (result != null)
            {
                result.MANV = Request.Form["manv"];

                result.TENPX = Request.Form["tenpx"];
                result.NGAYXUAT = DateTime.ParseExact(Request.Form["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                result.MAKH = Request.Form["makh"];
                db.SaveChanges();
            }
            Session.Remove("tab1");
            return RedirectToAction("Index1");
        }

        public ActionResult GetChitietpx()
        {
            return View(db.CHITIETPHIEUXUATs.ToList().OrderBy(a => a.MASP));
        }
    }
}