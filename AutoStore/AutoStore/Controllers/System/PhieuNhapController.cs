using AutoStore.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class PhieuNhapController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.PHIEUNHAPs.ToList().OrderBy(a => a.TENPN));
        }

        public ActionResult Index1()
        {
            return View(db.PHIEUNHAPs.ToList().OrderBy(a => a.TENPN));
        }

        public ActionResult getDataNHANVIEN()
        {
            var maNV = db.NHANVIENs.ToList().OrderBy(a => a.TENNV);
            return View(maNV);
        }

        public ActionResult getDataNHACUNGCAP()
        {
            var maNCC = db.NHACUNGCAPs.ToList().OrderBy(a => a.TENNCC);
            return View(maNCC);
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objmanv = Request.Form["manv"];
            string objtenpn = Request.Form["tenpn"];

            DateTime objngaynhap = DateTime.ParseExact(Request.Form["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string objmancc = Request.Form["mancc"];
            PHIEUNHAP temp = new PHIEUNHAP { MAPN = FuncClass.genNextCode(), TENPN = objtenpn, MANV = objmanv, NGAYNHAP = objngaynhap, MANCC = objmancc };
            db.PHIEUNHAPs.Add(temp);
            db.SaveChanges();
            Session.Remove("tab");
            return RedirectToAction("Index1");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new PHIEUNHAP { MAPN = ID };
            db.PHIEUNHAPs.Attach(temp);
            db.PHIEUNHAPs.Remove(temp);
            db.SaveChanges();
            Session.Remove("tab");
            return RedirectToAction("Index1");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.PHIEUNHAPs.SingleOrDefault(a => a.MAPN == id);
            if (result != null)
            {
                result.MANV = Request.Form["manv"];
                result.TENPN = Request.Form["tenpn"];
                //string obj = FuncClass.ConvertDateTime(Request.Form["date"]);
                result.NGAYNHAP = DateTime.ParseExact(Request.Form["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                result.MANCC = Request.Form["mancc"];
                db.SaveChanges();
            }
            Session.Remove("tab");
            return RedirectToAction("Index1");
        }

        public ActionResult GetChitiet()
        {
            return View(db.CHITIETPHIEUNHAPs.ToList().OrderBy(a => a.MASP));
        }
    }
}