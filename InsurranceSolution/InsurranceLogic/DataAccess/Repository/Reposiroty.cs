using InsurranceLogic.EFDataBaseConecction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected InsurranceDBModel Context = null;
        
        public Repository(InsurranceDBModel context)
        {
            Context = context;
        }

        protected DbSet DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }
        

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public virtual T Find(int id)
        {

            var obj = DbSet.Find(id);
            return (T)obj;
        }

        public virtual List<T> All() {
            List<T> objectsList = new List<T>();
            var objects = DbSet;
            foreach (var obj in objects)
                objectsList.Add((T)obj);
            return objectsList;
        }

        public virtual T Create(T T)
        {
            var newEntry = DbSet.Add(T);
            Context.SaveChanges();
            return (T)newEntry;
        }

        public virtual int Delete(T obj)
        {
            DbSet.Remove(obj);
            return Context.SaveChanges();
        }

        public virtual int Update(T T)
        {
            var entry = Context.Entry(T);
            DbSet.Attach(T);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}