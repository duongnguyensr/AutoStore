using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class NhanVienController : Controller
    {
        DBConnection db = new DBConnection();
        public ActionResult Index()
        {

            return View(db.NHANVIENs.ToList().OrderBy(a => a.TENNV));
        }

        [HttpPost]
        public ActionResult Insert(string sex)
        {
            string objname = Request.Form["name"];
            string objsex = Request.Form["sex"];
            string objphone = Request.Form["phone"];
            string objdiachi = Request.Form["adress"];
            string objusername = Request.Form["username"];
            string objpassword = Request.Form["password"];
            string objquyen = Request.Form["quyen"];
            NHANVIEN temp = new NHANVIEN { MANV = FuncClass.genNextCode(), TENNV = objname, GIOITINH = objsex, DIACHI = objdiachi, DIENTHOAI = objphone, USERNAME = objusername, PASSWORD = objpassword, PHANQUYEN = objquyen };
            db.NHANVIENs.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string ID)
        {
            var temp = new NHANVIEN { MANV = ID };
            db.NHANVIENs.Attach(temp);
            db.NHANVIENs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id)
        {
            var result = db.NHANVIENs.SingleOrDefault(a => a.MANV == id);
            if (result != null)
            {
                result.TENNV = Request.Form["name"];
                result.GIOITINH = Request.Form["sex"];
                result.DIACHI = Request.Form["adress"];
                result.DIENTHOAI = Request.Form["phone"];
                result.USERNAME = Request.Form["username"];
                result.PASSWORD = Request.Form["password"];
                result.PHANQUYEN = Request.Form["quyen"];
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