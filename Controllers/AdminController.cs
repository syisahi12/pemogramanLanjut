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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Admin userModel)
        {
            using (RatingDBEntities db = new RatingDBEntities())
            {
                var userDetails = db.Admins.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index",userModel);
                }
            }
            return View();
        }
        // GET: Admin
        public ActionResult List()
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
                return RedirectToAction("List");
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
                return RedirectToAction("List");
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
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
