
using AutoMapper;
using DAL.Models;
using DTO.Models;

namespace BL
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Language, LanguageDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
        }
    }
}
