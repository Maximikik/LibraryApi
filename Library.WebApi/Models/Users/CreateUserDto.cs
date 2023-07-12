using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Common.Mapping;
using Library.Application.Users.Commands.CreateUser;
using Library.WebApi.Models.Books;

namespace Library.WebApi.Models.Users;

public class CreateUserDto: IMapWith<CreateUserCommand>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDto, CreateUserCommand>()
               .ForMember(userCommand => userCommand.Email,
               opt => opt.MapFrom(user => user.Email))
               .ForMember(userCommand => userCommand.Password,
               opt => opt.MapFrom(user => user.Password));
    }
}
