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
    public class MissionQuestionsController : Controller
    {
        private ContextMissionary db = new ContextMissionary();

        // GET: MissionQuestions
        public ActionResult Index()
        {
            var missionQuestions = db.MissionQuestions.Include(m => m.Missions).Include(m => m.Users);
            return View(missionQuestions.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // GET: MissionQuestions/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName");
            ViewBag.userID = new SelectList(db.Users, "userID", "userEmail");
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "missionquestionID,missionID,userID,question,answer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.MissionQuestions.Add(missionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int user = db.Database.SqlQuery<int>("" +
                "SELECT * FROM Users" +
                "WHERE Users.userEmail = " + User.Identity.Name).FirstOrDefault();

            db.Database.ExecuteSqlCommand("" +
                "INSERT INTO MissionQuestions (missionID, userID, question) " +
                "VALUES(" + missionQuestion.missionID + ", " + user + ", '" + missionQuestion.question + "')" +
                "" +
                "");
            return RedirectToAction("Index");
            //ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            //ViewBag.userID = new SelectList(db.Users, "userID", "userEmail", missionQuestion.userID);
            //return View(missionQuestion);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userEmail", missionQuestion.userID);
            return View(missionQuestion);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionquestionID,missionID,userID,question,answer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.Database.ExecuteSqlCommand("" +
                "UPDATE MissionQuestions " +
                "SET answer = '" + missionQuestion.answer + "'" +
                "WHERE missionID = " + missionQuestion.missionID + "" +
                "AND missionquestionID = " + missionQuestion.missionquestionID + "");
            return RedirectToAction("ViewQuestions", "FAQ", new {id = missionQuestion.missionID });

            //ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            //ViewBag.userID = new SelectList(db.Users, "userID", "userEmail", missionQuestion.userID);
            //return View(missionQuestion);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            db.MissionQuestions.Remove(missionQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
