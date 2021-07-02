using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using AutoMapper;

namespace fahlen_dev_webapi.Profiles
{
    public class FoodsProfile : Profile
    {
        public FoodsProfile() {
            CreateMap<Account, AccountRead>();
            CreateMap<AccountCreate, Account>();
        }
    }
}