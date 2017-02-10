
using System.Collections.Generic;
using System.Dynamic;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface IProductService
    {
        Product Get(int id);

        List<Product> GetAll();

        List<Product> GetBySpecification(ISpecification<Product> specification);

        Product Add(Product product);

        void Update(Product product);

        void Delete(int id);

    }
}
