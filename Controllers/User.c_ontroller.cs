using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    public readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    // Get: api/v1/user => Read all user
    [HttpGet]
    public async Task<IActionResult> LoadUsers(string? search)
    {
        List<UserResDto> response = await _userService.GetAllUsers(search);
        return Ok(response);
    }

    // Post: api/v1/user => Create a new user
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userData)
    {
        UserResDto newUser = await _userService.CreateUser(userData);
        return Created($"/api/v1/user/{newUser.Id}", newUser);
    }
}