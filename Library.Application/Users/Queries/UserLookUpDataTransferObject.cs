using AutoMapper;
using Library.Application.Common.Mapping;
using Library.Domain;

namespace Library.Application.Users.Queries;

public class UserLookUpDataTransferObject : IMapWith<User>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserLookUpDataTransferObject>()
               .ForMember(userCommand => userCommand.Id,
               opt => opt.MapFrom(user => user.Id))
               .ForMember(userCommand => userCommand.Email,
               opt => opt.MapFrom(user => user.Email))
               .ForMember(userCommand => userCommand.Password,
               opt => opt.MapFrom(user => user.Password));
    }
}