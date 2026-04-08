using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        { 
            CreateMap<User, DTO_User>().ReverseMap();
        }

    }
}
