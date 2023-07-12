using AutoMapper;
using Library.Application.Books.Commands.DeleteBookById;
using Library.Application.Users.Commands.CreateUser;
using Library.Application.Users.Commands.EditUser;
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
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createBookDto)
    {
        var command = _mapper.Map<CreateUserCommand>(createBookDto);

        //command.UserId = UserId;

        var userId = await Mediator.Send(command);

        return Ok(userId);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditUserDto editBookDto)
    {
        var command = _mapper.Map<EditUserCommand>(editBookDto);

        //command.UserId = UserId;

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("Id/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        var command = new DeleteBookByIdCommand
        {
            Id = id
        };

        //command.UserId = UserId;

        await Mediator.Send(command);

        return NoContent();
    }
}
