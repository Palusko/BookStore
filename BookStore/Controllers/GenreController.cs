using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
                return View("Create");

            db.Genres.Add(genre);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }       

        [HttpGet]      
        public ActionResult Details(int? id)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = db.Genres.FirstOrDefault(g => g.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = db.Genres.FirstOrDefault(g => g.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Genre genre)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //var genreInDb = db.Genres.FirstOrDefault(g => g.Id == id);

            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = db.Genres.FirstOrDefault(g => g.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var genre = db.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null)
                return HttpNotFound();

            db.Genres.Remove(genre);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}