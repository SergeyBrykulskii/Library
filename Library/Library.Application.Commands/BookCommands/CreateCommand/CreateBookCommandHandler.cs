using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Commands.BookCommands.CreateCommand;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
{
    private readonly ILogger<CreateBookCommandHandler> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(
        ILogger<CreateBookCommandHandler> logger,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var Id = Guid.NewGuid();

        var author = await _authorRepository.FirstOrDefaultAsync(
            author => (author.FirstName + author.Surname) ==
            (request.createBookDTO.AuthorReply.FirstName + request.createBookDTO.AuthorReply.Surname), cancellationToken);

        if (author is null)
        {
            _logger.LogInformation($"Author hasn't been founded");
            return Unit.Value;
        }

        var isBookAlreadyExsist = await _bookRepository.FirstOrDefaultAsync(
           book => book.Title == request.createBookDTO.Title, cancellationToken);

        if (isBookAlreadyExsist is not null)
        {
            _logger.LogInformation($"this book with name {request.createBookDTO.Title} is already exist");
        }
        else
        {
            var book = new Book(Id, request.createBookDTO.Title, request.createBookDTO.ISBN,
                request.createBookDTO.Description, author.Id, request.createBookDTO.Genre);

            await _bookRepository.AddAsync(book, cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Book {book.Id} has been saved to db");
        }
        return Unit.Value;
    }
}
