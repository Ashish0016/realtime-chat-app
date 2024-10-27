using AutoMapper;
using Core.Feature.UserFeature.CreateUser;
using Core.Services.UserService;

namespace Core.MappingConfigurations
{
    public class UserMapperConfigurations : Profile
    {
        public UserMapperConfigurations()
        {
            CreateMap<CreateUserDto, CreateUserModel>();
        }
    }
}
