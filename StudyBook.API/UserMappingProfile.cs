using AutoMapper;
using StudyBookAPI.Models;

namespace StudyBookAPI
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Entities.User, GetUserDto>();
            CreateMap<UpdateUserDto, Entities.User>();
        }
    }
}
