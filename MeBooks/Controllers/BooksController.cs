using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeBooks.Entities;


namespace MeBooks.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            List<Books> m;
            using (var r = new BooksEntities())
            {
                m = r.Books.ToList();
            }
            return View(m);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                r.Books.Add(booksmodel);
                r.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string code)
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                booksmodel = r.Books.FirstOrDefault(x => x.BookCode == code);
            }

            return View(booksmodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string code)
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                booksmodel = r.Books.Where(x => x.BookCode == code).FirstOrDefault();
            }

            return View(booksmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string code)
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                var m = r.Books.Where(x => x.BookCode == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string code)
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                booksmodel = r.Books.FirstOrDefault(x => x.BookCode == code);
            }

            return View(booksmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string code)
        {
            var booksmodel = new Books();
            TryUpdateModel(booksmodel);

            using (var r = new BooksEntities())
            {
                var m = r.Books.Remove(r.Books.FirstOrDefault(x => x.BookCode == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}