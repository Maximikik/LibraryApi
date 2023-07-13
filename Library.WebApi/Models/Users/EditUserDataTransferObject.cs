using AutoMapper;
using Library.Application.Common.Mapping;
using Library.Application.Users.Commands.EditUser;

namespace Library.WebApi.Models.Users;

public class EditUserDataTransferObject: IMapWith<EditUserCommand>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<EditUserDataTransferObject, EditUserCommand>()
               .ForMember(userCommand => userCommand.Id,
               opt => opt.MapFrom(user => user.Id))
               .ForMember(userCommand => userCommand.Email,
               opt => opt.MapFrom(user => user.Email))
               .ForMember(userCommand => userCommand.Password,
               opt => opt.MapFrom(user => user.Password));
    }
}