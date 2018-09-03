using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.DataAccess.Repository
{
    interface IRepository<T> : IDisposable where T : class
    {

        T Find(int id);

        List<T> All();

        T Create(T t);

        int Delete(T obj);

        int Update(T t);
    }
}