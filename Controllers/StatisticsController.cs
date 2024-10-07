using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
      myportfolioEntities8 context =new myportfolioEntities8();
        public ActionResult Index()
        {
            int messagecount = context.messagetbl.Count();
            int messagecountısreadtrue=context.messagetbl.Where(x=> x.isread==true).Count();
            int messagecountısreadfalse=context.messagetbl.Where(x=> x.isread==false).Count();
            int skillcount = context.Skill.Count();
            var totalskillvalue = context.Skill.Sum(x => x.Value);
            var avergeskillvalue=context.Skill.Average(x => x.Value);
            var getemailfromprofile = context.Profile.Select(x=>x.Email).FirstOrDefault();
            var getlastcategorynid = context.Category.Max(x => x.Categoryid);
            var getlastcategoryname = context.Category.Where(x=>x.Categoryid==getlastcategorynid).Select(y=>y.CategoryName).FirstOrDefault();

            ViewBag.messagecount = messagecount;
            ViewBag.messagecountısreadtrue = messagecountısreadtrue;
            ViewBag.messagecountısreadfalse = messagecountısreadfalse;
            ViewBag.skillcount = skillcount;
            ViewBag.totalskillvalue = totalskillvalue;
            ViewBag.avergeskillvalue = avergeskillvalue;
            ViewBag.getemailfromprofile = getemailfromprofile;
            ViewBag.getlastcategoryname = getlastcategoryname;

            return View();
        }
    }
}