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
    public class DraftManager: IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void DraftDelete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }

        public Draft GetByIDBL(int id)
        {
            return _draftDal.Get(x => x.IDDraft == id);
        }

        public List<Draft> GetList()
        {
            return _draftDal.List();
        }

        public void DraftAddBL(Draft draft)
        {
            _draftDal.Insert(draft);
        }

    }
}
