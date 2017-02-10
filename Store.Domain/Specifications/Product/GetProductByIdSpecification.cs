using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;

namespace Store.Domain.Specifications.Product
{
    public class GetProductByIdSpecification :ISpecification<Models.Product>
    {
        private readonly int _id;
        public GetProductByIdSpecification(int id)
        {
            _id = id;
        }
        public Expression<Func<Models.Product, bool>> IsSatisfiedBy { get { return p => p.Id == _id; } }
    }
}
