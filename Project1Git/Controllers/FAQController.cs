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
               "WHERE Missions.MissionName =  '" + mission.missionName + "'").FirstOrDefault();
                return View("Index", ModelSwag);
           }
            else
            {
                return View("~/Views/Home/Missions");
            }
        }


        public ActionResult ViewQuestions(int? id)
        {
            IEnumerable<MissionQuestion> mq = db.Database.SqlQuery<MissionQuestion>("" +
                "SELECT * FROM MissionQuestions WHERE missionID = " + id + "");

            return View(mq);

        }
    }
}