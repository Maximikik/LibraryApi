using Library.WebApi.Models.Authentication;
using Library.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : BaseController
{
    public readonly AuthService _authService;

    public AuthenticationController(AuthService authService) =>
        _authService = authService;

    [HttpPost("Login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginDto request)
    {
        return await _authService.Login(request);
    }

    [HttpPost("Registration")]
    public async Task<ActionResult> Register([FromBody] RegisterDto request)
    {
        return await _authService.Register(request);
    }
}