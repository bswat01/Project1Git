using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1Git.DAL;
using Project1Git.Models;

namespace Project1Git.Controllers
{
    //[Authorize] Wait until I get this working :)
    public class FAQController : Controller
    {
        // GET: FAQ
        private ContextMissionary db = new ContextMissionary();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Missions(Mission mission)
        {
            if (ModelState.IsValid)
            {
                ViewBag.California = "Mission name: California Long Beach <br>" +
                    "Mission President's Name: Brian P. Patterson <br>" +
                    "Mission Address: 6500 E Atherton St, Long Beach, Ca, 90815 <br>" +
                    "Mission Language: English <br>" +
                    "Mission Climate: Mediterranean <br>" +
                    "Mission Dominate Religion: Christian <br>";
                ViewBag.Canada = "Mission name: Canada Calgary <br>" +
                    "Mission President's Name: Stephen A. Keung <br>" +
                    "Mission Address: 7044 Farrell Rd SE, Calgary, AB T2H 0T2, Canada <br>" +
                    "Mission Language: English <br>" +
                    "Mission Climate: Humid Continental <br>" +
                    "Mission Dominate Religion: Christian <br>";
                ViewBag.France = "Mission name: France Lyon <br>" +
                    "Mission President's Name: Christophe Gérard Giraud-Carrier <br>" +
                    "Mission Address: Lyon Business Centre, 59 rue de l’Abondance, 69003 Lyon, France <br>" +
                    "Mission Language: French <br>" +
                    "Mission Climate: Humid Sub-tropical <br>" +
                    "Mission Dominate Religion: Christian <br>";
                ViewBag.CaliforniaFlag = Url.Content("~/Content/Images/California.png");
                ViewBag.CanadaFlag = Url.Content("~/Content/Images/Canada.png");
                ViewBag.FranceFlag = Url.Content("~/Content/Images/France.png");

                return View("Index", mission);

           }
            else
            {
                return View("~/Views/Home/Missions");
            }
        }

        public ActionResult Missions()
        {
            ViewBag.Mission = db.Missions.ToList();

            return View();
        }
    }
}