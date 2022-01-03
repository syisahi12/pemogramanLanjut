using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRating.Models;

namespace WebAppRating.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (RatingDBEntities db = new RatingDBEntities())
            {
                return View(db.Articles.ToList());
            }
           
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Article articles)
        {
            try
            {
                // TODO: Add insert logic here
                using (RatingDBEntities db = new RatingDBEntities())
                {
                    db.Articles.Add(articles);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (RatingDBEntities db = new RatingDBEntities())
            {
                return View(db.Articles.Where(x => x.ArticleId == id).FirstOrDefault());
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Article article)
        {
            try
            {
                // TODO: Add update logic here
                using (RatingDBEntities db = new RatingDBEntities())
                {
                    db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (RatingDBEntities db = new RatingDBEntities())
            {
                return View(db.Articles.Where(x => x.ArticleId == id).FirstOrDefault());
            }
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                // TODO: Add delete logic here
                using (RatingDBEntities db = new RatingDBEntities())
                {
                    article = db.Articles.Where(x => x.ArticleId == id).FirstOrDefault();
                    db.Articles.Remove(article);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
