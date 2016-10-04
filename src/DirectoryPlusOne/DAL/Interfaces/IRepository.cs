using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DirectoryPlusOne.DAL.Interfaces
{
    public interface IRepository<T>
    {
        bool Insert(T entity);
        bool Delete(T entity);
        bool Delete(int entityid);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int entityid);
        bool InsertOrUpdate(T entity);
    }
}
