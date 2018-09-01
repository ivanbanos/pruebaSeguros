using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.DataAccess.Repository
{
    interface IRepository<T> where T : class
    {

        T Find(Expression<Func<T, bool>> predicate);

        T Create(T t);

        int Delete(Expression<Func<T, bool>> predicate);

        int Update(T t);
    }
}