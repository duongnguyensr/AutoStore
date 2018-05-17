using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class LoaiSanPhamController : Controller
    {
        DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.LOAISANPHAMs.ToList().OrderBy(a => a.TENLOAI));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string objname = Request.Form["name"];
            string objmota = Request.Form["mota"];
    
            LOAISANPHAM temp = new LOAISANPHAM { MALOAI = FuncClass.genNextCode(), TENLOAI = objname, MOTA = objmota};
            db.LOAISANPHAMs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID)
        {
            var temp = new LOAISANPHAM { MALOAI = ID };
            db.LOAISANPHAMs.Attach(temp);
            db.LOAISANPHAMs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.LOAISANPHAMs.SingleOrDefault(a => a.MALOAI == id);
            if (result != null)
            {
                result.TENLOAI = Request.Form["name"];
                result.MOTA = Request.Form["mota"];
                
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