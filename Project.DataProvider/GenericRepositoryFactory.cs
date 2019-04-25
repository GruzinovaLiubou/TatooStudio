using Project.DataProvider.Repositories;

namespace Project.DataProvider
{
    public class GenericRepositoryFactory
    {
        public static GenericRepository<TatooStudioDbContext> Create()
        {
            return new GenericRepository<TatooStudioDbContext>(new TatooStudioDbContext());
        }
    }
}
