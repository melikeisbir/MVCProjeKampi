using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter);  //ID'si 5 olan yazarı bununla bulurum. bunun ID olduğunu ICategoryServicede belirledik 
        void Delete (T p);
        void Update(T p);

        //şartlı listeleme istediğimiz ifadeleri getirecek
        List<T> List(Expression<Func<T, bool>> filter); //ismi Melike olan yazarı bununla bulurum
    }
}
