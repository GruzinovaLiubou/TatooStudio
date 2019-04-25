using AutoMapper;
using Project.DataProvider.Entities;
using Project.Model;

namespace Project.Logic.Mappings
{
    public class AccountMappingProfile: Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<RegistrationModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
