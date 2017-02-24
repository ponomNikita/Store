using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Domain.Specifications;

namespace Store.Domain.Services
{
    public class BaseEntityService<T> where T : TEntity
    {
        protected readonly IRepository<T> _repository;
        protected readonly ILogger _logger;

        protected BaseEntityService(IRepository<T> repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public List<T> GetBySpecification(ISpecification<T> specification)
        {
            _logger.InfoFormat("Getting {0}s by specification \"{1}\" from repository", typeof(T), specification.GetType());
            return _repository.GetBySpecification(specification).ToList();
        }

        public T Add(T entity)
        {
            _logger.InfoFormat("Add {0} to repository", typeof(T));
            var newEntity = _repository.Add(entity);
            _repository.Save();

            return newEntity;
        }

        public void Update(T entity)
        {
            _logger.InfoFormat("Update {0} with id {1}", typeof(T), entity.Id);
            _repository.Update(entity);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _logger.InfoFormat("Delete {0} with id {1}", typeof(T), id);
            _repository.Delete(id);
            _repository.Save();
        }

        public List<T> GetAll()
        {
            _logger.InfoFormat("Getting all {0}s from repository", typeof(T));
            GetAllSpecification<T> spec = new GetAllSpecification<T>();
            return _repository.GetBySpecification(spec).ToList();
        }

        public T Get(int id)
        {
            _logger.InfoFormat("Getting {0}s by id {1} from repository", typeof(T), id);
            GetByIdSpecification<T> spec = new GetByIdSpecification<T>(id);
            return _repository.GetBySpecification(spec).FirstOrDefault();
        }
    }
}
