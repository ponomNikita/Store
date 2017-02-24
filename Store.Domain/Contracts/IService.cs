
using System.Collections.Generic;
using System.Dynamic;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface IService <T>
        where T : TEntity
    {
        T Get(int id);

        List<T> GetAll();

        List<T> GetBySpecification(ISpecification<T> specification);

        T Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
