using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFwithDropdown.Models;

namespace EFwithDropdown.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            using (BooksEntities mentity = new BooksEntities())
            {
                var dataEF = new SelectList(mentity.Movies.ToList(), "MovieID", "MovieName");
                ViewData["MovEF"] = dataEF;
            }

            using (BooksEntities1 mentity = new BooksEntities1())
            {
                var booksEF = new SelectList(mentity.tbl_books.ToList(), "BookID","Title");
                ViewData["bookEF"] = booksEF;
            }
            return View();
        }


    }
}