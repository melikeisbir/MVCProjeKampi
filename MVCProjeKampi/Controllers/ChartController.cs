using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet); //kategori işlemleri için kullanılan bir
                                                                   //syntax komutu BlogList isminde yer alan metotta yer alan değerleri dondurecek
        }
        public List<CategoryClass> BlogList() //bu metotta veriler var
        {
            List<CategoryClass> ct= new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount =8 
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1  //1 adet değer
            });
            return ct;
        }
    }
}