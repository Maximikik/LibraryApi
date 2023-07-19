using AutoMapper;
using Library.Application.Common.Mapping;
using Microsoft.AspNetCore.Identity;

namespace Library.WebApi.Models.Authentication;

public class RegisterDto : IMapWith<IdentityUser>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterDto, IdentityUser>()
                .ForMember(to => to.UserName,
                    by => by.MapFrom(from => from.Email))
                .ForMember(to => to.Email,
                    by => by.MapFrom(from => from.Email))
                .ForAllMembers(members => members.Ignore());
    }
}