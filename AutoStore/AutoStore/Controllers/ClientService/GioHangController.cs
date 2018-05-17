using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.ClientService
{
    public class GioHangController : Controller
    {
        DBConnection db = new DBConnection();
        
        public ActionResult Index()
        {
            return View();
        }

        public void AddToCart(string idsp)
        {

            string clientuserid = (string)(Session["ClientUserID"]);
            var cartItem = db.GIOHANGs.SingleOrDefault(a =>  a.MASP == idsp && a.MAKH==clientuserid);
            if (cartItem == null)
            {
                GIOHANG temp = new GIOHANG { CODE = FuncClass.genNextCode(), MAKH = clientuserid, MASP = idsp, SOLUONG = 1};
                db.GIOHANGs.Add(temp);
               
            }
            else
            {
                
                
                cartItem.SOLUONG = cartItem.SOLUONG + 1;

            }
            // Save changes
            db.SaveChanges();
        }

        public ActionResult cart()
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            return PartialView(db.GIOHANGs.Include("SANPHAM").Where(a => a.MAKH== clientuserid).ToList());
        }
    }
}