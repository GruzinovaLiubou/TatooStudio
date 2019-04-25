using Project.DataProvider.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Project.DataProvider.Repositories
{
    public class GenericRepository<TContext> : GenericReadOnlyRepository<TContext>, IRepository
        where TContext: DbContext
    {
        public GenericRepository(TContext context)
            :base(context)
        {
        }

        public void Create<TEntity>(TEntity entity) where TEntity : BaseEntity<long>
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(object id) where TEntity : BaseEntity<long>
        {
            throw new System.NotImplementedException();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity<long>
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity<long>
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }
    }
}
