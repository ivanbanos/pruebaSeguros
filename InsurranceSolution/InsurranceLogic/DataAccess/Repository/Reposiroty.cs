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

        protected IQueryable Filter(Expression<Func<T, bool>> predicate)
        {
            return Filter(predicate);
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {

            var objects = Filter(predicate);
            foreach (var obj in objects)
                return (T)obj;
            return null;
        }

        public virtual T Create(T T)
        {
            var newEntry = DbSet.Add(T);
            Context.SaveChanges();
            return (T)newEntry;
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
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