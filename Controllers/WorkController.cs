using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class WorkController : Controller
    {
        myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult list()
        {
            var value = context.Work.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        public ActionResult delate(int id)
        {
            var value = context.Work.Find(id);
            context.Work.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var value = context.Work.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult update(Work work)
        {
            var value = context.Work.Find(work.Workid);
            value.Title = work.Title;
            value.Descripton = work.Descripton;
            value.ImageUrl= work.ImageUrl;
            value.GithubUrl = work.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}