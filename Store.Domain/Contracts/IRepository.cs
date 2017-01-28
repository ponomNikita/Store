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
        IEnumerable<T> Get();

        T Get(int id);

        bool Any(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Include(Expression<Func<T, object>> predicate);

        IEnumerable<T> GetBySpecification(ISpecification<T> spesification);

        T Add(T item);

        void Update(T item);

        void Delete(int id);

        void Save();
    }
}
