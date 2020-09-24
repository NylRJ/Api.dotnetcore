using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Api.Domain
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);

        Specification<T> And(ISpecification<T> specification);

        Specification<T> Or(ISpecification<T> specification);

        Expression<Func<T, bool>> SatisfyByCriteria();
    }
}
