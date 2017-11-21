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
    public class PositionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Positions
        public ActionResult Index()
        {
            return View(db.Positions.ToList());
        }
        public ActionResult PositionTechniques(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positions positions = db.Positions.Find(id);
            if (positions == null)
            {
                return HttpNotFound();
            }
            return View(positions);
        }
    }
}
