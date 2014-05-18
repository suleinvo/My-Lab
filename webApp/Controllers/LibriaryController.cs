using System.Data;
using System.Linq;
using System.Web.Mvc;
/*
 Имеется БД, состоящая из двух таблиц. Одна из таблиц ссылается на другую. 
 * Необходимо написать приложение, которое позволяет просматривать и редактировать данные в таблицах.
 * Приложение должно состоять из 2 страниц. На первой странице находится таблица с возможностью выделения 
 * произвольной строки, а также ссылка. По нажатию на ссылку открывается вторая страница, 
 * которая содержит записи, ссылающиеся на выделенную запись на 1ой странице.
 */
using webApp.Models;

namespace webApp.Controllers
{
    public class LibriaryController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var db = new LibriaryDb())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult User(int id = 0)
        {
            using (var db = new LibriaryDb())
            {
                return View(db.Users.Find(id));
            }
        }

        [HttpPost]
        public ActionResult User(User user)
        {
            using (var db = new LibriaryDb())
            {
                var updateUser = db.Users.Find(user.Id);
                updateUser.Id = user.Id;
                db.Entry(updateUser).CurrentValues.SetValues(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            using (var db = new LibriaryDb())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
	}
}