using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBookById;
using Library.Application.Books.Commands.DeleteBookByISBN;
using Library.Application.Books.Commands.EditBook;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Books.Queries.GetBooksList;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[Route("api/[controller]")]
public class BookController: BaseController
{
    private readonly IMapper _mapper;

    public BookController(IMapper mapper) => 
        _mapper = mapper;

    [HttpGet("BooksList")]
    public async Task<ActionResult<BooksListVm>> GetAll()
    {
        var query = new GetBooksListQuery { };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }
    
    [HttpGet("Id/{id}")]
    public async Task<ActionResult<Application.Books.Queries.GetBookById.BookVm>> GetById(Guid id )
    {
        var query = new GetBookByIdQuery
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("ISBN/{ISBN}")]
    public async Task<ActionResult<Application.Books.Queries.GetBookByISBN.BookVm>> GetByISBN(string ISBN)
    {
        var query = new GetBookByISBNQuery
        {
            ISBN = ISBN
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost] 
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
    {
        var command = _mapper.Map<CreateBookCommand>(createBookDto);

        //command.UserId = UserId;

        var bookId = await Mediator.Send(command);

        return Ok(bookId);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditBookDto editBookDto)
    {
        var command = _mapper.Map<EditBookCommand>(editBookDto);

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

    [HttpDelete("ISBN/{ISBN}")]
    public async Task<IActionResult> DeleteByISBN(string ISBN)
    {
        var command = new DeleteBookByISBNCommand
        {
            ISBN = ISBN
        };

        //command.UserId = UserId;

        await Mediator.Send(command);

        return NoContent();
    }
}
