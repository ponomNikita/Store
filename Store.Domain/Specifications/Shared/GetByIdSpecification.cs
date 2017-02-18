using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Specifications.Shared
{
    public class GetByIdSpecification<T> : ISpecification<T>
        where T: TEntity
    {
        private readonly int _id;

        public GetByIdSpecification(int id)
        {
            _id = id;
        }

        public Expression<Func<T, bool>> IsSatisfiedBy { get { return p => p.Id == _id; } }
    }
}
