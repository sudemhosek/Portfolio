using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class AboutController : Controller
    {
        myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult list()
        {
            var value = context.About.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        public ActionResult delate(int id)
        {
            var value = context.About.Find(id);
            context.About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult update(About about)
        {
            var value = context.About.Find(about.Aboutid);
            value.Title = about.Title;
            value.Detail = about.Detail;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}