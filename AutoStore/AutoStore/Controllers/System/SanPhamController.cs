using AutoStore.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class SanPhamController : Controller
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP));
        }

        public ActionResult getDataLOAISANPHAM()
        {
            var maL = db.LOAISANPHAMs.ToList().OrderBy(a => a.TENLOAI);
            return View(maL);
        }

        public ActionResult getDataNHASANXUAT()
        {
            var maNCC = db.NHASANXUATs.ToList().OrderBy(a => a.TENNSX);
            return View(maNCC);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="anh"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(HttpPostedFileBase anh)
        {
            string objtensp = Request.Form["tensp"];
            var check = db.SANPHAMs.SingleOrDefault(a => a.TENSP == objtensp);
            if (check == null)
            {
                string objmansx = Request.Form["mansx"];
                string objmausac = Request.Form["mausac"];
                string objmaloai = Request.Form["maloai"];
                string objmota = Request.Form["mota"];
                double objdongia = double.Parse(Request.Form["dongia"]);
                int objsoluong = Int32.Parse(Request.Form["soluong"]);
                int objnam = Int32.Parse(Request.Form["nam"]);
                int objkm = Int32.Parse(Request.Form["km"]);
                string objanh = "";
                if (anh != null)
                {
                    string pic = Path.GetFileName(anh.FileName);
                    objanh = "/Content/ClientVender/media/186x113/" + pic;
                    string path = Path.Combine(
                                           Server.MapPath("~/Content/ClientVender/media/186x113"), pic);
                    // file is uploaded
                    anh.SaveAs(path);
                }
                SANPHAM temp = new SANPHAM { MASP = FuncClass.genNextCode(), TENSP = objtensp, MANSX = objmansx, MAUSAC = objmausac, MALOAI = objmaloai, MOTA = objmota, DONGIA = objdongia, SOLUONG = objsoluong, YEAR = objnam, KM = objkm, HINHANH = objanh };
                db.SANPHAMs.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new SANPHAM { MASP = ID };
            db.SANPHAMs.Attach(temp);
            db.SANPHAMs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id, HttpPostedFileBase anh)
        {
            var result = db.SANPHAMs.SingleOrDefault(a => a.MASP == id);
            if (result != null)
            {
                result.TENSP = Request.Form["tensp"];
                result.MANSX = Request.Form["mansx"];
                result.MAUSAC = Request.Form["mausac"];
                result.MALOAI = Request.Form["maloai"];
                result.MOTA = Request.Form["mota"];
                result.DONGIA = double.Parse(Request.Form["dongia"]);
                result.SOLUONG = Int32.Parse(Request.Form["soluong"]);
                result.YEAR = Int32.Parse(Request.Form["nam"]);
                if (anh != null)
                {
                    string pic = Path.GetFileName(anh.FileName);
                    result.HINHANH = "/Content/ClientVender/media/186x113/" + pic;
                    string path = Path.Combine(
                                           Server.MapPath("~/Content/ClientVender/media/186x113"), pic);
                    // file is uploaded
                    anh.SaveAs(path);
                }

                result.KM = Int32.Parse(Request.Form["km"]);
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