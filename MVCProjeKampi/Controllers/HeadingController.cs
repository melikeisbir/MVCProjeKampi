using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueacategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value=x.CategoryID.ToString(),
                                                   }
                                                   ).ToList(); //ilgili tablonun bütün değerlerini alacak -- verileri dropdownlist aracılığıyla listeleyecek
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+ "" +x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc=valueacategory; //view tarafına taşıma
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ContentByHeading() //içeriğe göre başlık getirme
        {
            return View();
        }
    }
}