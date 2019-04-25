using Project.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.DataProvider.Repositories
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>()
            where TEntity : BaseEntity<long>;

        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : BaseEntity<long>;
    }
}
