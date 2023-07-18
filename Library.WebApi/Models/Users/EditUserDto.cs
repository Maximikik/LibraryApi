using AutoMapper;
using Library.Application.Common.Mapping;
using Library.Application.Users.Commands.EditUser;

namespace Library.WebApi.Models.Users;

public class EditUserDto: IMapWith<EditUserCommand>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<EditUserDto, EditUserCommand>()
               .ForMember(to => to.Id,
               by => by.MapFrom(from => from.Id))
               .ForMember(to => to.Email,
               by => by.MapFrom(from => from.Email))
               .ForMember(to => to.Password,
               by => by.MapFrom(from => from.Password));
    }
}