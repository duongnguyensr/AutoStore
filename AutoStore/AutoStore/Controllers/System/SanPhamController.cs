﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    public class SanPhamController : Controller
    {
        DBConnection db = new DBConnection();

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

        [HttpPost]
        public ActionResult Insert()
        {
            string objtensp = Request.Form["tensp"];
            string objmansx = Request.Form["mansx"];
            string objmausac = Request.Form["mausac"];
            string objmaloai = Request.Form["maloai"];
            string objmota = Request.Form["mota"];
            double objdongia = double.Parse(Request.Form["dongia"]);
            int objsoluong = Int32.Parse(Request.Form["soluong"]);
            int objnam = Int32.Parse(Request.Form["nam"]);
            int objkm = Int32.Parse(Request.Form["km"]);
            SANPHAM temp = new SANPHAM { MASP = FuncClass.genNextCode(), TENSP = objtensp, MANSX = objmansx, MAUSAC = objmausac, MALOAI = objmaloai ,MOTA = objmota,DONGIA = objdongia,SOLUONG = objsoluong,YEAR = objnam, KM =  objkm};
            db.SANPHAMs.Add(temp);
            db.SaveChanges();
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
        public ActionResult update(string id)
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
                //result.HINHANH = null;
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