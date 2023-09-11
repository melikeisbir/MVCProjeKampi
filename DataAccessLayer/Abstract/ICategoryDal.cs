﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        //CRUD operasyonunu metot olarak tanımlayacağız
        //Metotun tipi ismi ();  --->Type Name();

    }
}
