using Project.DataProvider.Entities;

namespace Project.DataProvider.Repositories
{
    public interface IRepository: IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity)
            where TEntity : BaseEntity<long>;

        void Update<TEntity>(TEntity entity)
            where TEntity : BaseEntity<long>;

        void Delete<TEntity>(object id)
            where TEntity : BaseEntity<long>;

        void Delete<TEntity>(TEntity entity)
            where TEntity : BaseEntity<long>;

        void Save();
    }
}
