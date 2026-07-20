using AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();

        CreateMap<User, UserResDto>();

        CreateMap<Team, UserResDto.TeamRes>();

        CreateMap<User, UserResDto.UserRes>()
            .ForMember(
                d => d.Name,
                o => o.MapFrom(s =>
                    string.IsNullOrWhiteSpace(s.LastName)
                        ? s.FirstName
                        : $"{s.FirstName} {s.LastName}")
            );
    }
}