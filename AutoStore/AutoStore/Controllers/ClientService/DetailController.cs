using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.ClientService
{
    public class DetailController : Controller
    {
        DBConnection db = new DBConnection();
        public ActionResult Index(string idsp)
        {
            return View(db.SANPHAMs.Where(a=>a.MASP==idsp).FirstOrDefault());
        }
    }
}