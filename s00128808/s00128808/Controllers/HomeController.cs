using s00128808.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s00128808.Controllers
{
    public class HomeController : Controller
    {
        private PremierLeagueDB db = new PremierLeagueDB();
 

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Clubs.ToList());
        }
    }
}
