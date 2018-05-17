using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.ClientService
{
    public class ClientLoginController : Controller
    {
        DBConnection db = new DBConnection();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult checklogin(string user,string pass)
        {

            var obj = db.KHACHHANGs.Where(a => a.USERNAME.Equals(user) && a.PASSWORD.Equals(pass)).FirstOrDefault();
            if (obj != null)
            {
                Session["ClientUserID"] = obj.MAKH.ToString();
                Session["ClientUserName"] = obj.TENKH.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Remove("ClientUserID");
            return RedirectToAction("Index", "Welcome");
        }

    }
}