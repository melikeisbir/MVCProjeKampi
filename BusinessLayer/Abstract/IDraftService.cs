using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetList();
        void DraftAddBL(Draft draft);
        Draft GetByIDBL(int id);
        void DraftDelete(Draft draft);
        void DraftUpdate(Draft draft);
    }
}
