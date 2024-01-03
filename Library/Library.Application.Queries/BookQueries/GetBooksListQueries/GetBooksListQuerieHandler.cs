using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Queries.BookQueries.GetBooksListQueries;

public class GetBooksListQuerieHandler : IRequestHandler<GetBooksListQuerie, BooksListReply>
{
    private readonly ILogger<GetBooksListQuerieHandler> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetBooksListQuerieHandler(
        ILogger<GetBooksListQuerieHandler> logger,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IMapper mapper)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<BooksListReply> Handle(GetBooksListQuerie request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetListAsync(cancellationToken);

        IList<BooksListDTO> booksDTO = new List<BooksListDTO>();

        foreach (var item in books)
        {

            booksDTO.Add(bookMap(item, cancellationToken).Result);
        }

        _logger.LogInformation(books is null
            ? $"Failed to get all books from db"
            : $"Books has been retrieved from db");

        return new BooksListReply { Books = booksDTO };
    }

    private async Task<BooksListDTO> bookMap(Book book, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(book.AuthorId, cancellationToken);

        if (author is null)
        {
            _logger.LogInformation($"Author hasn't been founded");
        }

        var authorReply = _mapper.Map<AuthorReply>(author);


        return new BooksListDTO
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Genre = book.Genre,
            AuthorReply = authorReply
        };
    }
}
