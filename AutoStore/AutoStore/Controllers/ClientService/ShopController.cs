using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;


namespace AutoStore.Controllers
{
    public class ShopController : Controller
    {
        DBConnection db = new DBConnection();
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP));
        }
    }
}