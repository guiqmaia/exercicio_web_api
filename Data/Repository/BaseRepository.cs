using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Model;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        public string Create(T entity)
        {
            using (DbContext context = new DbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            return "Criado";
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            using (DbContext context = new DbContext())
            {
               list = context.Set<T>().ToList();
            }
            return list;
        }
    }
}
