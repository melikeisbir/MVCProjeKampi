﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        MessageManager cm = new MessageManager(new EfMessageDal());
        //MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messagelist = cm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = cm.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View(p);
        }
    }
}