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
    public class PhieuXuatController : Controller
    {
        DBConnection db = new DBConnection();

        public ActionResult Index()
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
            string obj = Request.Form["date"];
            string objtenpn = Request.Form["tenpn"];
            DateTime objngaynhap = DateTime.ParseExact(obj, "d/M/yyyy", CultureInfo.InvariantCulture);
            string objmakh = Request.Form["mancc"];
            PHIEUXUAT temp = new PHIEUXUAT { MAPX = FuncClass.genNextCode(), TENPX=objtenpn, MANV = objmanv, NGAYXUAT = objngaynhap, MAKH = objmakh };
            db.PHIEUXUATs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID)
        {
            var temp = new PHIEUXUAT { MAPX = ID };
            db.PHIEUXUATs.Attach(temp);
            db.PHIEUXUATs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.PHIEUXUATs.SingleOrDefault(a => a.MAPX == id);
            if (result != null)
            {
                result.MANV = Request.Form["manv"];
                string obj = FuncClass.ConvertDateTime(Request.Form["date"]);
                result.TENPX = Request.Form["tenpn"];
                result.NGAYXUAT = DateTime.ParseExact(obj, "d/M/yyyy", CultureInfo.InvariantCulture);
                result.MAKH = Request.Form["mancc"];
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