using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Commands.BookCommands.UpdateCommand;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly ILogger<UpdateBookCommandHandler> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public UpdateBookCommandHandler(
        ILogger<UpdateBookCommandHandler> logger,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.FirstOrDefaultAsync(
            author => (author.FirstName + author.Surname) ==
            (request.updateBookDTO.AuthorReply.FirstName + request.updateBookDTO.AuthorReply.Surname), cancellationToken);

        if (author is null)
        {
            _logger.LogInformation($"Author hasn't been founded");
        }

        var updateBook = await _bookRepository.FirstOrDefaultAsync(book => book.Id == request.updateBookDTO.Id,
                cancellationToken);

        if (updateBook is null)
        {
            _logger.LogInformation($"Book with id: {request.updateBookDTO.Id} doesn't exist in db");
        }
        else
        {
            var book = new Book(request.updateBookDTO.Id, request.updateBookDTO.Title, request.updateBookDTO.ISBN,
                request.updateBookDTO.Description, request.updateBookDTO.RecieveDate,
                request.updateBookDTO.ReturnDate, author.Id, request.updateBookDTO.Genre);

            await _bookRepository.UpdateAsync(book, cancellationToken);
            _logger.LogInformation($"Book {book.Id} has been updated in db");
        }
        return Unit.Value;
    }
}
