using Microsoft.AspNet.Identity.EntityFramework;
using Project.DataProvider.Entities;
using Project.DataProvider.Interfaces;

namespace Project.DataProvider
{
    public class UserManagerFactory
    {
        public IUserManager Create()
        {
            var dbContext = new TatooStudioDbContext();
            return new UserManager(new UserStore<User>(dbContext));
        }
    }
}
