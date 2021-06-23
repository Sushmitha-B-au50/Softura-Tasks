using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCusgDPR.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Dapper;
using System.Diagnostics;

namespace MVCusgDPR.Controllers
{
    [ActionExceptionPhilter]

   

    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> BKlist = new List<BookModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKlist = dbcon.Query<BookModel>("select* from tbl_books").ToList();
            }
                return View(BKlist);
        }

        // GET: Book/Details/5

        [HandleError(View="error")]
        public ActionResult Details(int id)
        {
            try
            {
                BookModel Bklist = new BookModel();
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    Bklist = dbcon.Query<BookModel>("select* from books where BooKID=" + id, new { id }).SingleOrDefault();
                }
                return View(Bklist);
            }
            catch (Exception e)
            {
                throw;

            }
            
        }

        // GET: Book/Create
        public ActionResult Create(int id)
        {
            BookModel Bklist = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<BookModel>("select* from tbl_books where BooKID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);
         
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bmodel)
        {
            try
            {
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "insert into tbl_books(Title, AuthorID, price)" +
                        "Values('" + bmodel.Title + "','" + bmodel.AuthorID + "','" + bmodel.Price + "')";
                    int rowins = dbcon.Execute(sqlQry);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookModel Bklist = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<BookModel>("select* from tbl_books where BooKID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string sqlQry = "update  tbl_Books set Title='" + bmodel.Title + "',AuthorID=" + bmodel.AuthorID + ",Price=" + bmodel.Price + " where BookId=" + bmodel.BookID;
                int rowedit = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");
        }
        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            BookModel Bklist = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<BookModel>("select* from tbl_books where BooKID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);
        
           
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookModel bmodel)
        {
            try
            {
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "delete from  tbl_books where BookID =" +id;
                    int rowupd = dbcon.Execute(sqlQry);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        class ActionExceptionPhilter : ActionFilterAttribute, IExceptionFilter
        {
          public void OnException(ExceptionContext filterContext)
            {
              var ctrlName = filterContext.RouteData.Values["Controller"];
                var actName = filterContext.RouteData.Values["action"];
                Trace.WriteLine("Exception occurs " + DateTime.Now.ToString() + " " + ctrlName.ToString() + " " + "From the method" + " " + actName.ToString());
            }
        }
    }
}
