using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class profileController : Controller
    {myportfolioEntities8 context = new myportfolioEntities8();
        public ActionResult list()
        {
            var value = context.Profile.ToList();
            return View(value);
        }

        public ActionResult delate(int id)
        {
            var value = context.Profile.Find(id);
            context.Profile.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var value = context.Profile.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult update(Profile profile)
        {
            var value = context.Profile.Find(profile.Profileid);
            value.Title = profile.Title;
            value.Description = profile.Description;
            value.Address = profile.Address;
            value.Email = profile.Email;
            value.PhoneNumber = profile.PhoneNumber;
            value.Github = profile.Github;
            value.ImageUrl = profile.ImageUrl;
            value.MapLocation = profile.MapLocation;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}