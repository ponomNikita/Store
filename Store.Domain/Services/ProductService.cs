using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Domain.Specifications.Product;

namespace Store.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Get(int id)
        {
            GetProductByIdSpecification spec = new GetProductByIdSpecification(id);
            return _repository.FirstOrDefault(spec);
        }

        public List<Product> GetAll()
        {
            GetAllProductsSpecification spec = new GetAllProductsSpecification();
            return _repository.GetBySpecification(spec).ToList();
        }

        public List<Product> GetBySpecification(ISpecification<Product> specification)
        {
            return _repository.GetBySpecification(specification).ToList();
        }

        public Product Add(Product product)
        {
            var newProduct = _repository.Add(product);
            _repository.Save();

            return newProduct;
        }

        public void Update(Product product)
        {
            _repository.Update(product);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
