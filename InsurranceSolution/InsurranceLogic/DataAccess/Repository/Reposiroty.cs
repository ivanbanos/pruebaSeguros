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

        protected DbSet dbSet
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

            var obj = dbSet.Find(id);
            return (T)obj;
        }

        public virtual T FindByExpr(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefault(predicate);
        }

        public virtual List<T> All() {
            List<T> objectsList = new List<T>();
            var objects = dbSet;
            foreach (var obj in objects)
                objectsList.Add((T)obj);
            return objectsList;
        }

        public virtual T Create(T T)
        {
            var newEntry = dbSet.Add(T);
            Context.SaveChanges();
            return (T)newEntry;
        }

        public virtual int Delete(T obj)
        {
            dbSet.Remove(obj);
            return Context.SaveChanges();
        }

        public virtual int Update(T T)
        {
            var entry = Context.Entry(T);
            dbSet.Attach(T);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}