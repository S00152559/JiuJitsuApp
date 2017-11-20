using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JiuJitsuNotes.Models;
using jiujitsuNotes.Models.NotesModel;

namespace JiuJitsuNotes.Controllers
{
    public class TechniquesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Techniques
        public ActionResult Index()
        {
            var techniques = db.Techniques.Include(t => t.EndPosition).Include(t => t.StartPosition);
            return View(techniques.ToList());
        }

        // GET: Techniques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techniques techniques = db.Techniques.Find(id);
            if (techniques == null)
            {
                return HttpNotFound();
            }
            return View(techniques);
        }

        // GET: Techniques/Create
        public ActionResult Create()
        {
            ViewBag.EndPositionID = new SelectList(db.Positions, "PositionID", "PositionName");
            ViewBag.StartPositionID = new SelectList(db.Positions, "PositionID", "PositionName");
            return View();
        }

        // POST: Techniques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechniqueID,TechniqueName,StartPositionID,EndPositionID,TechniqueType,DateAdded,StartingCondition,Steps,KeyPoints,CommonMistakes")] Techniques techniques)
        {
            if (ModelState.IsValid)
            {

                db.Techniques.Add(techniques);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EndPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.EndPositionID);
            ViewBag.StartPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.StartPositionID);
            return View(techniques);
        }

        // GET: Techniques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techniques techniques = db.Techniques.Find(id);
            if (techniques == null)
            {
                return HttpNotFound();
            }
            ViewBag.EndPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.EndPositionID);
            ViewBag.StartPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.StartPositionID);
            return View(techniques);
        }

        // POST: Techniques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechniqueID,TechniqueName,StartPositionID,EndPositionID,TechniqueType,DateAdded,StartingCondition,Steps,KeyPoints,CommonMistakes")] Techniques techniques)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techniques).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EndPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.EndPositionID);
            ViewBag.StartPositionID = new SelectList(db.Positions, "PositionID", "PositionName", techniques.StartPositionID);
            return View(techniques);
        }

        // GET: Techniques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Techniques techniques = db.Techniques.Find(id);
            if (techniques == null)
            {
                return HttpNotFound();
            }
            return View(techniques);
        }

        // POST: Techniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Techniques techniques = db.Techniques.Find(id);
            db.Techniques.Remove(techniques);
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
