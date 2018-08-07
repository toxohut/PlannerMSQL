using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlannerMSQL.Models;

namespace PlannerMSQL
{
    public class VotingAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VotingAnswers
        public ActionResult Index()
        {
            var votingAnswers = db.VotingAnswers.Include(v => v.Voting);
            return View(votingAnswers.ToList());
        }

        // GET: VotingAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = db.VotingAnswers.Find(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            return View(votingAnswer);
        }

        // GET: VotingAnswers/Create
        public ActionResult Create()
        {
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name");
            return View();
        }

        // POST: VotingAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VotingAnswerId,VotingId,AnswerText")] VotingAnswer votingAnswer)
        {
            if (ModelState.IsValid)
            {
                db.VotingAnswers.Add(votingAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", votingAnswer.VotingId);
            return View(votingAnswer);
        }

        // GET: VotingAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = db.VotingAnswers.Find(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", votingAnswer.VotingId);
            return View(votingAnswer);
        }

        // POST: VotingAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VotingAnswerId,VotingId,AnswerText")] VotingAnswer votingAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votingAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", votingAnswer.VotingId);
            return View(votingAnswer);
        }

        // GET: VotingAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = db.VotingAnswers.Find(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            return View(votingAnswer);
        }

        // POST: VotingAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VotingAnswer votingAnswer = db.VotingAnswers.Find(id);
            db.VotingAnswers.Remove(votingAnswer);
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
