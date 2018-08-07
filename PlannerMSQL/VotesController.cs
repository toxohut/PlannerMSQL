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
    public class VotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = db.Votes.Include(v => v.Voting).Include(v => v.VotingAnswer);
            return View(votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name");
            ViewBag.VotingAnswerId = new SelectList(db.VotingAnswers, "VotingAnswerId", "AnswerText");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,VotingId,OpenAnswer,VotingAnswerId")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", vote.VotingId);
            ViewBag.VotingAnswerId = new SelectList(db.VotingAnswers, "VotingAnswerId", "AnswerText", vote.VotingAnswerId);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", vote.VotingId);
            ViewBag.VotingAnswerId = new SelectList(db.VotingAnswers, "VotingAnswerId", "AnswerText", vote.VotingAnswerId);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteId,VotingId,OpenAnswer,VotingAnswerId")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VotingId = new SelectList(db.Votings, "VotingId", "Name", vote.VotingId);
            ViewBag.VotingAnswerId = new SelectList(db.VotingAnswers, "VotingAnswerId", "AnswerText", vote.VotingAnswerId);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.Votes.Find(id);
            db.Votes.Remove(vote);
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
