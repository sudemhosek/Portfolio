using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;
using PagedList;
using PagedList.Mvc;
using System.Collections;
using System.Web.Helpers;

namespace Proje1Portfolio.Controllers
{
    public class SkillController : Controller
    {
        myportfolioEntities8 context = new myportfolioEntities8();

        // GET: Skill
        public ActionResult SkillList(int sayfa=1)
        { 
            var values=context.Skill.ToList().ToPagedList(sayfa,5);
     
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DelateSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public JsonResult GetSkillData()
        {
            var veri = context.Skill.Select(x => new
            {
                Title = x.Title,
                Value = x.Value
            }).ToList();

            return Json(veri, JsonRequestBehavior.AllowGet);
        }


    }
}