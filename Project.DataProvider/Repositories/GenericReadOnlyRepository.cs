using Project.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Project.DataProvider.Repositories
{
    public class GenericReadOnlyRepository<TContext> : IReadOnlyRepository
        where TContext : DbContext
    {
        protected readonly TContext context;

        public GenericReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetAll<TEntity>()
            where TEntity: BaseEntity<long>
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : BaseEntity<long>
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
