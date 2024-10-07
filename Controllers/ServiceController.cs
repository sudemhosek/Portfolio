using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        myportfolioEntities8 context =
            new myportfolioEntities8();
        public ActionResult list()
        {
            var value = context.Service.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("list");

        }

        public ActionResult delate(int id)
        {
            var value = context.Service.Find(id);
            context.Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]

        public ActionResult update(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult update(Service service)
        {
            var value = context.Service.Find(service.Serviceid);
            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}
