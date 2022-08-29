﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repository
{
    internal interface IRepository<T> where T : BaseModel
    {
        string Create(T entity);
        List<T> GetAll();
    }
}
