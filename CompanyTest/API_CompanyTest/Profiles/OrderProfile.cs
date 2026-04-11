using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, DTO_Order>().ReverseMap();
        }
    }
}
