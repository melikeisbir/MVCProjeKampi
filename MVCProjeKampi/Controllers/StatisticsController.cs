using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            Context context = new Context();
            ViewBag.CategoryCount = context.Categories.Count();
            ViewBag.Heading = context.Categories.Count(x => x.CategoryID==18);
            ViewBag.Writer = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.MaxHeading = context.Categories.Max(x => x.CategoryName);
            ViewBag.Status = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            return View();
        }
    }
}