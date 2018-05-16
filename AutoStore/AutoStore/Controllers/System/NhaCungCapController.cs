using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoStore.Models;

namespace AutoStore.Controllers.System
{
    public class NhaCungCapController : Controller
    {
        DBConnection db = new DBConnection();

        public ActionResult Index()
        {
            return View(db.NHACUNGCAPs.ToList().OrderBy(a=>a.TENNCC));
        }
    }
}