using AutoMapper;
using Project.DataProvider;
using Project.DataProvider.Entities;
using Project.DataProvider.Interfaces;
using Project.DataProvider.Repositories;
using Project.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Logic.Servicies
{
    public class AccountService
    {
        private readonly IUserManager _userManager;
        private readonly IRepository _repository;

        public AccountService()
        {
            _userManager = new UserManagerFactory().Create();
            _repository = GenericRepositoryFactory.Create();
        }

        public IEnumerable<Service> Test()
        {
            return _repository.GetAll<Service>();
        } 

        public async Task<IEnumerable<string>> CreateUser (RegistrationModel user)
        {
            var newUser = Mapper.Map<User>(user);
            return await _userManager.CreateUserAsync(newUser, user.Password);
        }

        public async Task<ClaimsIdentity> FindUserAndGetClaimsAsync(LoginModel loginInfo, string authType)
        {
            var user = await _userManager.FindAsync(loginInfo.Email, loginInfo.Password);
            return await _userManager.CreateIdentityAsync(user, authType);
        }

        public async Task<IEnumerable<string>> UpdateUserAsync(UserViewModel updatedUser)
        {
            var oldUser = await _userManager.FindByIdAsync(updatedUser.Id);
            Mapper.Map(updatedUser, oldUser);
            var userResult = await _userManager.UpdateAsync(oldUser);
            return userResult.Errors;
        }

        public async Task<UserViewModel> FindUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return Mapper.Map<UserViewModel>(user);
        }
    }
}
