using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        myportfolioEntities8 contrxt=new myportfolioEntities8();
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in contrxt.Category.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.Categoryid.ToString()
                                       }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
       public ActionResult Index(messagetbl messagetbl)
        {
            messagetbl.senddate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messagetbl.isread = false;
            contrxt.messagetbl.Add(messagetbl);
            contrxt.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult pertialhead()
        {
            return PartialView();
        }

        public PartialViewResult pertialnavbar()
        {
            return PartialView();
        }

        public PartialViewResult partialheader()
        {
            ViewBag.title =contrxt.About.Select(a => a.Title).FirstOrDefault();
            ViewBag.detail =contrxt.About.Select(a => a.Detail).FirstOrDefault();
            ViewBag.ımg =contrxt.About.Select(a => a.ImageUrl).FirstOrDefault();

            ViewBag.address=contrxt.Profile.Select(a => a.Address).FirstOrDefault();
            ViewBag.email=contrxt.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.phone=contrxt.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.github=contrxt.Profile.Select(a => a.Github).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult partialabout()
        {
            ViewBag.title = contrxt.Profile.Select(a=> a.Title).FirstOrDefault();
            ViewBag.des = contrxt.Profile.Select(a=> a.Description).FirstOrDefault();
            ViewBag.phone = contrxt.Profile.Select(a=> a.PhoneNumber).FirstOrDefault();
            ViewBag.email = contrxt.Profile.Select(a=> a.Email).FirstOrDefault();
            ViewBag.img = contrxt.Profile.Select(a=> a.ImageUrl).FirstOrDefault();
            
            return PartialView();
        }
        public PartialViewResult partialeducationt()
        { var values =contrxt.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult partialscrip()
        {
            return PartialView();
        }

        public PartialViewResult partialskill()
        {
            var values = contrxt.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult partialsocialmedia()
        {
            var values = contrxt.SocialMedia.Where(x=>x.STATUS==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult partialExperience()
        {var value =contrxt.Experience.ToList();
            return PartialView(value);
        }

        public PartialViewResult partialService()
        {
            var value = contrxt.Service.ToList();
            return PartialView(value);
        }

        public PartialViewResult partialProje()
        {
            var value = contrxt.Work.ToList();
            return PartialView(value);
        }

        public PartialViewResult partialTestimonial()
        {
            var value = contrxt.Testimonial.ToList();
            return PartialView(value);
        }
    }

}