public interface ITeamService
{
    Task<List<TeamResDto>> GetAllTeams(string? search);
    Task<List<SelectTeamRes>> SelectTeams();
    // Task<TeamResDto?> GetTeamById(int id);
    Task<int> CreateTeam(CreateTeamDto createData);
    // Task<bool> UpdateTeam(int id, UpdateTeamDto updateData);
    // Task<bool> DeleteTeam(int id);
}