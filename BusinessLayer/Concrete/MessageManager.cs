using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "mel@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "mel@gmail.com");
        }

        public int GetUnReadenInboxNumber(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.MessageIsReaden == false).Count();
        }

        public int GetUnReadenSendboxNumber(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.MessageIsReaden == false).Count();
        }
    }
}
