using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phliters.Controllers
{
    [ActionPhilter]
    public class PhliterController : Controller/*, IActionFilter*/
    {
        // GET: Phliter

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyIndex()
        {
            return View("Index");
        }
    }

        class ActionPhilter : ActionFilterAttribute, IActionFilter
        {
            void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
            {
                Trace.WriteLine(filterContext.ActionDescriptor + "Method  executed Sucessfully" + DateTime.Now.ToString());
                //after action method executes
            }

            void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
            {
            var ctrlName = filterContext.RouteData.Values["Controller"];
            var actName = filterContext.RouteData.Values["action"];
            Trace.WriteLine(filterContext.RouteData +" Method  is executing " + DateTime.Now.ToString() + " " + ctrlName.ToString() + "From the method" + " "+ actName.ToString());
                //before action method executes
               // filterContext.Result = new RedirectResult("https://www.digiterati.com/");
            }

       
    }
    }
