using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class SocielMediaController : Controller
    {
    myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult List()
        {var value =context.SocialMedia.ToList();
            return View(value);
        }
        public ActionResult changetrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.ıd == id).FirstOrDefault();
            value.STATUS = true;
            context.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult changefalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.ıd == id).FirstOrDefault();
            value.STATUS = false;
            context.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var VALUE = context.SocialMedia.Find(id);
            return View(VALUE);
        }
        [HttpPost]
        public ActionResult update(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.ıd);
            value.title = socialMedia.title;
            value.ICON = socialMedia.ICON;
            value.Url = socialMedia.Url;
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}