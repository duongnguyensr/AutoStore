using AutoStore.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.Controllers.ClientService
{
    public class GioHangController : Controller
    {
        private DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loaditem()
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            return View(db.GIOHANGs.Include("SANPHAM").Where(a => a.MAKH == clientuserid).ToList());
        }

        public void AddToCart(string idsp)
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            var cartItem = db.GIOHANGs.SingleOrDefault(a => a.MASP == idsp && a.MAKH == clientuserid);
            if (cartItem == null)
            {
                GIOHANG temp = new GIOHANG { CODE = FuncClass.genNextCode(), MAKH = clientuserid, MASP = idsp, SOLUONG = 1 };
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
            return PartialView(db.GIOHANGs.Include("SANPHAM").Where(a => a.MAKH == clientuserid).ToList());
        }

        /// <summary>
        /// delete item in cart
        /// </summary>
        /// <param name="idkh"></param>
        /// <param name="idsp"></param>
        public void delitem(string idkh, string idsp)
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            var temp = db.GIOHANGs.SingleOrDefault(a => a.MASP == idsp && a.MAKH == clientuserid);
            if (temp != null)
            {
                if (temp.SOLUONG == 1)
                {
                    db.GIOHANGs.Remove(temp);
                }
                if (temp.SOLUONG > 1)
                {
                    temp.SOLUONG = temp.SOLUONG - 1;
                }
            }
            db.SaveChanges();
        }

        /// <summary>
        /// delete item in checkout
        /// </summary>
        /// <param name="idkh"></param>
        /// <param name="idsp"></param>
        public void delitem2(string idsp)
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            var temp = db.GIOHANGs.SingleOrDefault(a => a.MASP == idsp && a.MAKH == clientuserid);
            if (temp != null)
            {
                db.GIOHANGs.Remove(temp);
            }
            db.SaveChanges();
        }

        public void decrease(int i, string idsp)
        {
            string clientuserid = (string)(Session["ClientUserID"]);
            var cartItem = db.GIOHANGs.SingleOrDefault(a => a.MASP == idsp && a.MAKH == clientuserid);
            if (cartItem != null)
            {
                cartItem.SOLUONG = i;
                db.SaveChanges();
            }
        }

        public ActionResult Checkout()
        {
            string objmanv = "1211997";
            string objtenpn = "Phiếu xuất hàng " + (string)(Session["ClientUserID"]);
            DateTime objngaynhap = DateTime.Today;
            string objmakh = (string)(Session["ClientUserID"]);
            PHIEUXUAT temp = new PHIEUXUAT { MAPX = FuncClass.genNextCode(), TENPX = objtenpn, MANV = objmanv, NGAYXUAT = objngaynhap, MAKH = objmakh };
            db.PHIEUXUATs.Add(temp);
            db.SaveChanges();
            return View();
        }
    }
}