using AutoMapper;
using testMongo.Dto;
using testMongo.Models;

namespace testMongo.Profiles
{
    public class LoginProfiles : Profile
    {
        public LoginProfiles()
        {
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
        }
    }
}
