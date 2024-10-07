using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class contactController : Controller
    {
       myportfolioEntities8 context = new myportfolioEntities8();
        public PartialViewResult partialcontactsidebar()
        {
            return PartialView();
        }

        public PartialViewResult partialcontactaddress()
        {
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult partialcontactlocation()
        {ViewBag.maplocation =context.Profile.Select(x=>x.MapLocation).FirstOrDefault();
            return PartialView();
        }
    }
}