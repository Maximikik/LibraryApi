using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Library.WebApi.Models.Authentication;

public class LoginDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoginDto, IdentityUser>()
                .ForMember(to => to.UserName,
                    by => by.MapFrom(from => from.Email))
                .ForMember(to => to.PasswordHash,
                    by => by.MapFrom(from => from.Password));
    }
}
