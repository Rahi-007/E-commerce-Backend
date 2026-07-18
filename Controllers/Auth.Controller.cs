using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[AllowAnonymous]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    public readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Post: api/v1/auth => login user
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginData)
    {
        LoginResDto response = await _authService.UserLogin(loginData);
        return Ok(response);
    }
}