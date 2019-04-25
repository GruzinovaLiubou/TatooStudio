using Project.DataProvider.Entities;

namespace Project.DataProvider.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity: BaseEntity<TKey>
    {

    }
}
