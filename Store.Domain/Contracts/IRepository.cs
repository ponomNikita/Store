using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface IRepository<T> where T : TEntity
    {
        IQueryable<T> Get();

        T Get(int id);

        bool Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> Include(Expression<Func<T, object>> predicate);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        T Create(T item);

        void Update(T item);

        void Delete(int id);

        void Save();
    }
}
