using Microsoft.AspNet.Identity;
using Project.DataProvider.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.DataProvider.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<string>> CreateUserAsync(User user, string password);

        Task<User> FindAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        Task<IdentityResult> UpdateAsync(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByIdAsync(string userId);
    }
}
