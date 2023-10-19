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
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EfDraftDal());

        public ActionResult Index()
        {
            var draftValues = dm.GetList();
            return View(draftValues);
        }

        [HttpGet]
        public ActionResult EditDraft(int id)
        {
            var draft = dm.GetByIDBL(id);
            return View(draft);
        }

        [HttpPost]
        public ActionResult EditDraft(Draft draft)
        {
            dm.DraftUpdate(draft);
            return RedirectToAction("Index");
        }
    }
}