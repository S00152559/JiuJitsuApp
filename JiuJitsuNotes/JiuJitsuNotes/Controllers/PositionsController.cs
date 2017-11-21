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

    }
}
