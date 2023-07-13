using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBookById;
using Library.Application.Books.Commands.DeleteBookByISBN;
using Library.Application.Books.Commands.EditBook;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Books.Queries.GetBooksList;
using Library.WebApi.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[Route("api/[controller]")]
public class BookController: BaseController
{
    private readonly IMapper _mapper;

    public BookController(IMapper mapper) => 
        _mapper = mapper;

    [HttpGet("BooksList")]
    public async Task<ActionResult<BooksListViewModel>> GetAll()
    {
        var query = new GetBooksListQuery { };

        var booksViewModel = await Mediator.Send(query);

        return Ok(booksViewModel);
    }
    
    [HttpGet("Id/{id}")]
    public async Task<ActionResult<Application.Books.Queries.GetBookByISBN.BookViewModel>> GetById(Guid id )
    {
        var query = new GetBookByIdQuery
        {
            Id = id
        };

        var bookViewModel = await Mediator.Send(query);

        return Ok(bookViewModel);
    }

    [HttpGet("ISBN/{ISBN}")]
    public async Task<ActionResult<Application.Books.Queries.GetBookByISBN.BookViewModel>> GetByISBN(string ISBN)
    {
        var query = new GetBookByISBNQuery
        {
            ISBN = ISBN
        };

        var bookViewModel = await Mediator.Send(query);

        return Ok(bookViewModel);
    }

    [HttpPost] 
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDataTransferObject createBookDto)
    {
        var command = _mapper.Map<CreateBookCommand>(createBookDto);

        var bookId = await Mediator.Send(command);

        return Ok(bookId);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditBookDataTransferObject editBookDto)
    {
        var command = _mapper.Map<EditBookByIdCommand>(editBookDto);

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

        await Mediator.Send(command);

        return NoContent();
    }
}