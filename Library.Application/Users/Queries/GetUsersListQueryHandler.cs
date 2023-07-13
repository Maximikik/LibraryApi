using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Users.Queries;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
{
    private readonly ILibraryDbContext _libraryDbContext;
    private readonly IMapper _mapper;
    public GetUsersListQueryHandler(ILibraryDbContext context, IMapper mapper) =>
        (_libraryDbContext, _mapper) = (context, mapper);

    public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var usersList = await _libraryDbContext.Users
            .ProjectTo<UserLookUpDataTransferObject>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new UsersListViewModel { Users = usersList };
    }
}