using CITB517_website_cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITB517_website_cs.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            using (LoginDB db = new LoginDB())
            {
                var comments = db.Comments.ToList();
                ViewBag.Comments = comments;
                return View("Feedback");
            }
        }

        public ActionResult Comments(string username)
        {
            using (LoginDB db = new LoginDB())
            {
                var comments = db.Comments.Where(x => x.Commenter == username).ToList();
                ViewBag.Comments = comments;
                return View("Comments");
            }
        }

        public ActionResult SubmitComment(Comment comment)
        {
            using (LoginDB db = new LoginDB())
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}