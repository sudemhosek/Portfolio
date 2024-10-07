using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class ExperienceController : Controller
    {myportfolioEntities8 context =new myportfolioEntities8();
        // GET: Experience
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult list() 
        {
            var value = context.Experience.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Experience experience) 
        { context.Experience.Add(experience);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        public ActionResult delate(int id)
        { var value = context.Experience.Find(id);
            context.Experience.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var experience = context.Experience.Find(id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult update(Experience experience)
        {
            var value = context.Experience.Find(experience.Experienceid);
            value.Title = experience.Title;
            value.Description = experience.Description;
            value.WorkDate = experience.WorkDate;
            value.CompanyName = experience.CompanyName;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}