using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers
{
    [SessionTimeout]
    public class ChiTietPhieuNhapController : Controller
    {
        DBConnection db = new DBConnection();

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
            CHITIETPHIEUNHAP temp = new CHITIETPHIEUNHAP { MAPN = objmapn, MASP = objmasp, SOLUONG = objsoluong, DONGIANHAP = objdongia};
            db.CHITIETPHIEUNHAPs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID,string IDSP)
        {
            var temp = new CHITIETPHIEUNHAP { MAPN = ID, MASP = IDSP};
            db.CHITIETPHIEUNHAPs.Attach(temp);
            db.CHITIETPHIEUNHAPs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id,string idsp)
        {
            var result = db.CHITIETPHIEUNHAPs.SingleOrDefault(a=>a.MAPN == id && a.MASP == idsp);
            if (result != null)
            {
                //result.MAPN = Request.Form["tenpn"];
                //result.MASP = Request.Form["tensp"];
                result.SOLUONG = Int32.Parse(Request.Form["soluong"]);
                result.DONGIANHAP = double.Parse(Request.Form["dongia"]);
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