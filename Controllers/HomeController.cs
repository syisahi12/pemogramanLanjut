using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRating.Models;
using WebAppRating.ViewModel;

namespace WebAppRating.Controllers
{
    public class HomeController : Controller
    {
        public RatingDBEntities objRatingDBEntities;
        public HomeController()
        {
            objRatingDBEntities = new RatingDBEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<ArticleViewModel> listOfArticleViewModel = (from objArticle in objRatingDBEntities.Articles
                                                                    select new ArticleViewModel()
                                                                    {
                                                                        ArticleDescription = objArticle.ArticleDescription,
                                                                        ArticleId = objArticle.ArticleId,
                                                                        ArticleName = objArticle.ArticleName,
                                                                    }).ToList();
            return View(listOfArticleViewModel);
        }

        public ActionResult ShowComment (int articleId)
        {
            IEnumerable<CommentViewModel> listOfCommentViewModels = (from objComment in objRatingDBEntities.Comments
                                                                     where objComment.ArticleId == articleId
                                                                     select new CommentViewModel()
                                                                     {
                                                                         ArticleId = objComment.ArticleId,
                                                                         CommentDescription = objComment.CommentDescription,
                                                                         CommentId = objComment.CommentId,
                                                                         CommentedOn = objComment.CommentedOn,
                                                                         Rating = objComment.Rating,
                                                                     }).ToList();
            ViewBag.ArticleId = articleId;
            return View(listOfCommentViewModels);
        }
        [HttpPost]
        public ActionResult AddComment(int articleId, int rating, string articleComment)
        {
            Comment objComment = new Comment();
            objComment.ArticleId = articleId;
            objComment.CommentDescription = articleComment;
            objComment.CommentedOn = DateTime.Now;
            objComment.Rating = rating;
            objComment.GuestId = Guid.NewGuid();
            objRatingDBEntities.Comments.Add(objComment);
            objRatingDBEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}