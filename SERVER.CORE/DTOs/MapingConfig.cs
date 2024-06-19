using AutoMapper;
using SERVER.CORE.DTOs.Users;
using SERVER.CORE.Entities;

namespace SERVER.CORE.DTOs
{
    public class MapingConfig:Profile
    {
        public MapingConfig()
        {
            CreateMap<User, CreateRequest>().ReverseMap();
            CreateMap<User, UpdateRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}