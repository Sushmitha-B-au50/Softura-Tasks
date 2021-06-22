using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingDapper.Models;

namespace UsingDapper.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MoviesModel> BKlist = new List<MoviesModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKlist = dbcon.Query<MoviesModel>("select * from Movies").ToList();
            }
            return View(BKlist);
           
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            MoviesModel Bklist = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<MoviesModel>("select * from Movies where MovieID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);
           
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MoviesModel bmodel)
        {
            try
            {
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string query = "Insert into Movies(MovieName) values('" + bmodel.MovieName + "')";
                    int rowIns = dbcon.Execute(query);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MoviesModel Bklist = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<MoviesModel>("select* from Movies where MovieID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);

        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MoviesModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bmodel = dbcon.Query<MoviesModel>("update Movies set MovieName='" + bmodel.MovieName + "' where MovieID=" + id).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            MoviesModel Bklist = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<MoviesModel>("select* from Movies where MovieID=" + id, new { id }).SingleOrDefault();
            }
            return View(Bklist);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "delete from  Movies where MovieID =" + id;
                    int rowupd = dbcon.Execute(sqlQry);
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
