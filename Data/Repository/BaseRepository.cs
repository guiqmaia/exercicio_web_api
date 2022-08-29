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
        public virtual string Create(T entity)
        {
            using (DbContext context = new DbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            return "Criado";
        }

        public virtual string Update(T entity)
        {
            using (DbContext Context = new DbContext())
            {
                Context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();

            }
            return "Alterado";
        }

        public virtual string Delete(int id)
        {
            using (DbContext context = new DbContext())
            {
                context.Entry<T>(this.GetById(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
            return "Deletado";
        }

        public virtual List<T> GetAll()
        {
            List<T> list = new List<T>();
            using (DbContext context = new DbContext())
            {
               list = context.Set<T>().ToList();
            }
            return list;
        }

        public virtual T GetById(int id)
        {
            T model = null;
            using (DbContext context = new DbContext())
            {
                model = context.Set<T>().Find(id);
            }
            return model;
        }
    }
}
