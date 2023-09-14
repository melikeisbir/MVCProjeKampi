using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager();  //businessLayerda oluşturduğumuz sınıfı çağırıyoruz
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetAllBL(); //var değişkeni sayısal, alfabetik veriler, karakterleri kapsıyor
            return View(categoryvalues);
        }
    }
}