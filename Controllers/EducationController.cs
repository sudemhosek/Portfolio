using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class EducationController : Controller
    {myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult educationlist()
        {
            var value = context.Education.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult createEducation() 
        { return View(); }

        [HttpPost]
        public ActionResult createEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("educationlist");
            
        }

        public ActionResult delate(int id)
        {
            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("educationlist");
        }


        [HttpGet]

        public ActionResult update(int id)
        {
            var experience = context.Education.Find(id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult update(Education education)
        {
            var value = context.Education.Find(education.Educationid);
            value.Title = education.Title;
            value.EducationDate = education.EducationDate;
            value.Subbitle = education.Subbitle;
            value.Description = education.Description;
           
            context.SaveChanges();
            return RedirectToAction("educationlist");
        }
    }
}