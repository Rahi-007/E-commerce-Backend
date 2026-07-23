using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/v1/team")]
public class TeamController : ControllerBase
{
    public readonly ITeamService _teamService;
    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // Get: api/v1/team => Read all teams
    [HttpGet]
    public async Task<IActionResult> LoadUsers(string? search)
    {
        List<TeamResDto> response = await _teamService.GetAllTeams(search);
        return Ok(response);
    }

    // Get: api/v1/team/select => Select teams
    [HttpGet("select")]
    public async Task<IActionResult> SelectTeams()
    {
        List<SelectTeamRes> response = await _teamService.SelectTeams();
        return Ok(response);
    }

    // Post: api/v1/team => Create a new team
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateTeamDto teamData)
    {
        int teamId = await _teamService.CreateTeam(teamData);
        return Created($"/api/v1/user/{teamId}", teamId);
    }
}