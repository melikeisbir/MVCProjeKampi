using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager vm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var WriterValues=vm.GetList();
            return View(WriterValues);
        }
    }
}