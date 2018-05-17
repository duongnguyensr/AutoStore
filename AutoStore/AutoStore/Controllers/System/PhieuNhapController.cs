using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;
using System.Globalization;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class PhieuNhapController : Controller
    {

        DBConnection db = new DBConnection();
        public ActionResult Index()
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
            string obj = Request.Form["date"];
            DateTime objngaynhap = DateTime.ParseExact(obj, "d/M/yyyy", CultureInfo.InvariantCulture);
            string objmancc = Request.Form["mancc"];
            PHIEUNHAP temp = new PHIEUNHAP { MAPN = FuncClass.genNextCode(),TENPN = objtenpn, MANV = objmanv , NGAYNHAP=objngaynhap, MANCC = objmancc};
            db.PHIEUNHAPs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID)
        {
            var temp = new PHIEUNHAP { MAPN = ID };
            db.PHIEUNHAPs.Attach(temp);
            db.PHIEUNHAPs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.PHIEUNHAPs.SingleOrDefault(a => a.MAPN == id);
            if (result != null)
            {
                result.MANV = Request.Form["manv"];
                result.TENPN = Request.Form["tenpn"];
                string obj = FuncClass.ConvertDateTime(Request.Form["date"]);
                result.NGAYNHAP = DateTime.ParseExact(obj, "d/M/yyyy", CultureInfo.InvariantCulture);
                result.MANCC = Request.Form["mancc"];
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