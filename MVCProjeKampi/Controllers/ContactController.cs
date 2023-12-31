﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        
        // GET: Contact
        Context _context = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv= new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        
        public ActionResult Index()
        {
            var contactvalues=cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id) 
        {
            var contactvalues= cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            var receiverMail = _context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(x => x.SenderMail == "admin@gmail.com").ToString();
            ViewBag.senderMail = senderMail;

            var contact = _context.Contact.Count().ToString();
            ViewBag.contact = contact;
            string mail = (string)Session["WriterMail"];
            ViewBag.inbox = mm.GetUnReadenInboxNumber(mail);
            ViewBag.sendbox = mm.GetUnReadenSendboxNumber(mail);
            return PartialView();
        }
    }
}