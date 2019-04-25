using Microsoft.AspNet.Identity;
using Project.DataProvider.Entities;
using Project.DataProvider.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.DataProvider
{
    public class UserManager : UserManager<User>, IUserManager
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public async Task<IEnumerable<string>> CreateUserAsync(User user, string password)
        {
            var identityResult = await base.CreateAsync(user, password);
            return identityResult.Errors;
        }
    }
}