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

        public ActionResult Missions()
        {
            ViewBag.Mission = db.Missions.ToList();

            return View();
        }

        [HttpPost] 
        [Authorize]
        public ActionResult Missions(Mission mission)
        {
            if (mission.missionName != null)
            {

                var ModelSwag = db.Database.SqlQuery<Mission>("SELECT * " +
                "FROM Missions " +
               "WHERE Missions.Name =  '" + mission.missionName + "'");


                return View("Index", ModelSwag);

           }
            else
            {
                return View("~/Views/Home/Missions");
            }
        }

     
    }
}