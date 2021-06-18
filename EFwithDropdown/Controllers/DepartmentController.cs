using EFwithDropdown.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EFwithDropdown.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        //public ActionResult Index()
        //{
        //    using (AdventureWorksEntities department = new AdventureWorksEntities())
        //    {
        //        var dataEF = new SelectList(department.Departments.ToList(), "DepartmentID", "Name");
        //        TempData["depEF"] = dataEF;
        //    }
        //    return View();
        //}

        //public ActionResult EmployeeDetails(string name)
        //{
        //    TempData["depEF"] = name;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult EmployeeDetails()
        //{


        //    EmployeeDetails emp = new EmployeeDetails();
        //    string Depname = (string)TempData["depEF"];
        //    int rowIns = emp.DisplayEmployee(Depname);
        //    return View(Depname);
        //}
        public ActionResult Index()
        {
            EmployeeDetails mdl = new EmployeeDetails();
            DataTable dt = mdl.GetDepartment();
            return View("Index",dt);
        }

        public ActionResult EmployeeDetails()
        {
            EmployeeDetails mdl = new EmployeeDetails();
            return View();
        }
        public ActionResult Employee(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                EmployeeDetails mdl = new EmployeeDetails();
                string Depname = frm["txtname"];
                TempData["Dept"] = Depname;
                DataTable dt = mdl.DisplayEmployee(Depname);
                return View("EmployeeDetails",dt);

            }

            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

