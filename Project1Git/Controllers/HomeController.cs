using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Git.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //JAXON KNOWS HOW TO USE GIT!!!
        //comment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Missions()
        {
            ViewBag.California = "Mission name: Long Beach, California <br>" +
                "Mission President's Name: Brian P. Patterson <br>" +
                "Mission Address: 6500 E Atherton St, Long Beach, Ca, 90815 < br>" +
                "Mission Language: English <br>" +
                "Mission Climate: Mediterranean <br>" +
                "Mission Dominate Religion: Christian <br>";
            ViewBag.Canada = "Mission name: Calgary, Canada" +
                "Mission President's Name: Stephen A. Keung <br>" +
                "Mission Address: 7044 Farrell Rd SE, Calgary, AB T2H 0T2, Canada < br>" +
                "Mission Language: English <br>" +
                "Mission Climate: humid continental<br>" +
                "Mission Dominate Religion: Christian <br>";
            ViewBag.France = "Mission name: Lyon, France" +
                "Mission President's Name: Jarom Barnes <br>" +
                "Mission Address: Lyon Business Centre, 59 rue de l’Abondance, 69003 Lyon, France < br>" +
                "Mission Language: French <br>" +
                "Mission Climate: Humid Sub-tropical <br>" +
                "Mission Dominate Religion: Christian <br>";
            ViewBag.CaliforniaFlag = Url.Content("~/Content/Images/California.png");
            ViewBag.CanadaFlag = Url.Content("~/Content/Images/Canada.png");
            ViewBag.FranceFlag = Url.Content("~/Content/Images/France.png");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}