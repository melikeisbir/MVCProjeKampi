using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        //CRUD operasyonunu metot olarak tanımlayacağız
        //Metotun tipi ismi ();  --->Type Name();
        List<Category> List(); //türü ve ismi list olan bir metot tanımlandı
        void Insert(Category p); //ekleme işlemi
        void Update(Category p);
        void Delete(Category p);

    }
}
