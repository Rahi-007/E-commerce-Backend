using AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UserResDto, User>().ReverseMap();
    }
}