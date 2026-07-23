using AutoMapper;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<CreateTeamDto, Team>();
        CreateMap<User, TeamResDto.UserRes>()
            .ForMember(
                d => d.Name,
                o => o.MapFrom(s =>
                    string.IsNullOrWhiteSpace(s.LastName)
                        ? s.FirstName
                        : $"{s.FirstName} {s.LastName}")
            );
        CreateMap<Team, TeamResDto>();
        CreateMap<Team, SelectTeamRes>();
    }
}