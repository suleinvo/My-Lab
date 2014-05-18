using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApp.Models;

namespace webApp.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index(int userId)
        {
            using (var db = new LibriaryDb())
            {
                return View(db.Users.Find(userId).Books.ToList());
            }
        }

        public ActionResult Book(int id)
        {
            using (var db = new LibriaryDb())
            {
                return View(db.Books.Find(id));
            }
        }

        [HttpPost]
        public ActionResult CreateBook(Book book, int userId)
        {
            using (var db = new LibriaryDb())
            {
                db.Users.Find(userId).Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
	}
}