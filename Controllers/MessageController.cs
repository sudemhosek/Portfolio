using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class MessageController : Controller
    {
        myportfolioEntities8 context = new myportfolioEntities8();
        // GET: Message
        public ActionResult Inbox()
        {
            var values = context.messagetbl.ToList();
            return View(values);
        }

        public ActionResult Messagedetail(int? id)
        {
            var value =context.messagetbl.Where(x => x.Messageid == id).FirstOrDefault();
         value.isread = true;
            context.SaveChanges();
            return View(value);
        }
        public ActionResult MessageStatuChangeToTrue(int id)
        {
            var value = context.messagetbl.Where(x => x.Messageid == id).FirstOrDefault();
            value.isread = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageStatuChangeToFalse(int id)
        {
            var value = context.messagetbl.Where(x => x.Messageid == id).FirstOrDefault();
            value.isread = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult delate(int id)
        {
            var value = context.messagetbl.Find(id);
            context.messagetbl.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
    }