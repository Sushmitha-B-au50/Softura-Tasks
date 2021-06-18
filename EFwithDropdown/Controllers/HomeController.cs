using EFwithDropdown.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDropdown.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            return RedirectToAction("GoHome","Home");
        }
      
        public ActionResult GoHome()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            ViewData["time1"] = DateTime.Now.ToString();
            TempData["temptime"]= DateTime.Now.ToString(); 
            return View("Home");
        }

        //public ActionResult Linq()
        //{
        //    SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
        //    con.Open();
        //    BooksEntities1 book = new BooksEntities1();
        //    SqlCommand cmd = new SqlCommand(((from i in book.tbl_books select i).ToString()), con) ; 
        //    con.Close();
        //    return View(cmd);
        //}
    }
}