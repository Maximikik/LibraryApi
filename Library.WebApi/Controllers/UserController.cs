using AutoMapper;
using Library.Application.Users.Commands.CreateUser;
using Library.Application.Users.Commands.DeleteUser;
using Library.Application.Users.Commands.EditUser;
using Library.Application.Users.Queries;
using Library.WebApi.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[Route("api/[controller]")]
public class UserController: BaseController
{
    private readonly IMapper _mapper;

    public UserController(IMapper mapper) =>
        _mapper = mapper;

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDataTransferObject createBookDto)
    {
        var command = _mapper.Map<CreateUserCommand>(createBookDto);

        var userId = await Mediator.Send(command);

        return Ok(userId);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditUserDataTransferObject editBookDto)
    {
        var command = _mapper.Map<EditUserCommand>(editBookDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<UsersListViewModel>> Get()
    {
        var query = new GetUsersListQuery { };

        var usersListViewModel = await Mediator.Send(query);

        return Ok(usersListViewModel);
    }
}