using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project1Git.DAL;
using Project1Git.Models;

namespace Project1Git.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ContextMissionary db = new ContextMissionary();

        public ActionResult Index()
        {
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

        public ActionResult SubmitQuestion()
        {
            return View(db.Missions.ToList());
        }

        [Authorize]
        [HttpGet]
        public ActionResult AskQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var found = db.Database.SqlQuery<MissionQuestion>("SELECT *FROM MissionQuestions WHERE missionID = " + id + "").FirstOrDefault();

            if (found == null)
            {
                return HttpNotFound();
            }
            return View(found);
        }
        [HttpPost]
        public ActionResult AskQuestions(MissionQuestion missionQuestion)
        {
            int user = db.Database.SqlQuery<int>("" +
                "SELECT * FROM Users" +
                "WHERE Users.userEmail = " + User.Identity.Name).FirstOrDefault();
            missionQuestion.userID = user;
            if (ModelState.IsValid)
            {
                db.MissionQuestions.Add(missionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userEmail", missionQuestion.userID);
            return View(missionQuestion);
        }

        [Authorize]
        public ActionResult NewMission()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMission([Bind(Include = "missionID,missionName,missionPresidentName,missionAddress,Language,Climate,DominateReligion,Flag")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(mission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mission);
        }

        public ActionResult signUp()
        {
            //add ability to create account record in database with view
            //linked from login page (i.e. "Dont have an account? Sign up here")
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login, bool rememberMe = false)
        {
            //login authentication from login view
            //authentication already added to Web.config
            //should return to login view if not authenticated from any view

            string email = login.Username;
            string password = login.Password;

            var found = db.Database.SqlQuery<User>("" +
                "SELECT * FROM Users WHERE UserEmail = '" + email + "' AND password = '" + password + "'"
                );

           
            if (found.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }

        }
    }
}