using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        DraftManager dm = new DraftManager(new EfDraftDal());
        MessageValidator messagevalidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p, String draftButton, String sendButton)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (!string.IsNullOrEmpty(sendButton))

                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            if (!string.IsNullOrEmpty(draftButton))
            {
                Draft _draft = new Draft();
                _draft.DraftMessageContent = p.MessageContent;
                _draft.DraftMessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _draft.DraftReceiverMail = p.ReceiverMail;
                _draft.DraftSenderMail = p.SenderMail;
                _draft.DraftSubject = p.Subject;
                dm.DraftAddBL(_draft);
                return RedirectToAction("Index", "Draft");
            }
            return View();
        }
        public ActionResult Readen(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = true;
            mm.MessageUpdate(values);
            return RedirectToAction("Inbox");
        }

        public ActionResult UnReaden(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = false;
            mm.MessageUpdate(values);
            return RedirectToAction("Inbox");
        }

        public ActionResult SenReaden(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = true;
            mm.MessageUpdate(values);
            return RedirectToAction("Sendbox");
        }

        public ActionResult SenUnReaden(int id)
        {
            var values = mm.GetByID(id);
            values.MessageIsReaden = false;
            mm.MessageUpdate(values);
            return RedirectToAction("Sendbox");
        }
    }
}