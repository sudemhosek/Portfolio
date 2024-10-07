using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1Portfolio.Models;

namespace Proje1Portfolio.Controllers
{
    public class AdminController : Controller
    {
       myportfolioEntities8 contrxt = new myportfolioEntities8();
        public ActionResult Index()
        {
            return View();
        }public PartialViewResult partialHead() 
        {   
            return PartialView();
        }
        public PartialViewResult partialsidebar()
        {
            ViewBag.img = contrxt.About.Select(a => a.ImageUrl).FirstOrDefault();

            return PartialView(); }
         
        public PartialViewResult partianavbar()
        { 
            return PartialView(); 
        }

        public ActionResult CvIndir()
        {
            // Dosya yolunu kontrol edin
            var filePath = Server.MapPath("~/Content/images/CV.JPG");

            // Eğer dosya yoksa bir hata döndür
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "CV.JPG";
            var contentType = "image/jpeg";

            // Dosya indirilebilir olarak döndür
            return File(filePath, contentType, fileName);
        }
    }
}