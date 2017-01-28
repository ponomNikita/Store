using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface ISpecification<T>
        where T: TEntity
    {
        Expression<Func<T, bool>> IsSatisfiedBy { get; set; }
    }
}
