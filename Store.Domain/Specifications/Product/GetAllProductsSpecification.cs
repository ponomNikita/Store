using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;

namespace Store.Domain.Specifications.Product
{
    public class GetAllProductsSpecification : ISpecification<Models.Product>
    {
        public Expression<Func<Models.Product, bool>> IsSatisfiedBy { get { return p => true; } }
    }
}
