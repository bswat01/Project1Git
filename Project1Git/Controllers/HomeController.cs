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

        public ActionResult AskQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        public ActionResult NewMission()
        {
            return View();
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

            if (string.Equals(email, "greg@test.com") && (string.Equals(password, "greg")))
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