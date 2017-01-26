
using System.Collections.Generic;
using System.Dynamic;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    interface IProductService
    {
        Product Get(int id);

        List<Product> GetAll();

        void Add(Product product);

        void Update(Product product);

        void Delete(int id);

    }
}
