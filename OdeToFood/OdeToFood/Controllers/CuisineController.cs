using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Filters;

namespace OdeToFood.Controllers
{
    //[Authorize]
    [Log]
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "french")
        {
            throw new Exception("Something terrible has happened");

            // prevents cross tag malicious scripting. Only happens when using content
            var message = Server.HtmlEncode(name);

            return Content(message);
            //return Json(new {Message = message, Name = "Matthew"}, JsonRequestBehavior.AllowGet);
            //return File(Server.MapPath("~/Content/site.css"), "text/css");
            //return View();
        }
    }
}