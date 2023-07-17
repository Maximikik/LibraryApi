using AutoMapper;
using Library.WebApi.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Services;

public class AuthService
{
    private readonly TokenProvider _tokenProvider;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    public AuthService(TokenProvider tokenProvider, UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _tokenProvider = tokenProvider;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ActionResult<object>> Login(LoginDto request)
    {
        var managedUser = await _userManager.FindByEmailAsync(request.Email);

        if (managedUser is null)
            return new BadRequestObjectResult("Bad credentials");

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

        if (!isPasswordValid)
            return new BadRequestObjectResult("Bad credentials");

        var accessToken = _tokenProvider.CreateToken(managedUser);

        var response = new
        {
            managedUser.Id,
            managedUser.Email,
            accessToken,
        };

        return new OkObjectResult(response);
    }

    public async Task<ActionResult> Register(RegisterDto request)
    {
        var user = _mapper.Map<IdentityUser>(request);

        if (request.Password != request.ConfirmPassword)
            return new BadRequestObjectResult("Invalid password confirm");

        var result = await _userManager.CreateAsync(user, request.Password).ConfigureAwait(false);

        if (!result.Succeeded)
            return new BadRequestObjectResult(result.Errors.Select(x => x.Description));

        return new OkResult();
    }
}