using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
       myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult list()
        {
            var value = context.Testimonial.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        public ActionResult delate(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult update(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.Testimonianiaid);
            value.Name = testimonial.Name;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            value.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}