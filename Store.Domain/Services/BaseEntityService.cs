using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Domain.Specifications.Shared;

namespace Store.Domain.Services
{
    public class BaseEntityService<T> where T : TEntity
    {
        private readonly IRepository<T> _repository;

        public BaseEntityService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetBySpecification(ISpecification<T> specification)
        {
            return _repository.GetBySpecification(specification).ToList();
        }

        public T Add(T entity)
        {
            var newEntity = _repository.Add(entity);
            _repository.Save();

            return newEntity;
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public List<T> GetAll()
        {
            GetAllSpecification<T> spec = new GetAllSpecification<T>();
            return _repository.GetBySpecification(spec).ToList();
        }

        public T Get(int id)
        {
            GetByIdSpecification<T> spec = new GetByIdSpecification<T>(id);
            return _repository.GetBySpecification(spec).FirstOrDefault();
        }
    }
}
