using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        string city = "a";
        public ActionResult categorylist()
        {
            return View();
        }
        public ActionResult createcategory() 
        {
            return View();
        }
    }
}