using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext db;
        public GenreController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Genre
        public ActionResult Index()
        {
            //var genres = db.Genres;
            return View(db.Genres.ToList());
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {            
            return View("Create");
        }
        */
                
        public ActionResult Create()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}