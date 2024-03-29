﻿using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Commands.AuthorCommands.UpdateCommand;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly ILogger<UpdateAuthorCommandHandler> _logger;
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorCommandHandler(ILogger<UpdateAuthorCommandHandler> logger, IAuthorRepository authorRepository)
    {
        _logger = logger;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var updateAuthor = await _authorRepository.FirstOrDefaultAsync(author => author.Id == request.updateAuthorDTO.Id,
                cancellationToken);

        if (updateAuthor is null)
        {
            _logger.LogInformation($"this Author with id {request.updateAuthorDTO.Id} doesn't exist in db");
        }
        else
        {
            var author = new Author(request.updateAuthorDTO.Id, request.updateAuthorDTO.FirstName,
                    request.updateAuthorDTO.Surname);

            await _authorRepository.UpdateAsync(author, cancellationToken);
            _logger.LogInformation($"Author {request.updateAuthorDTO.Id} has been updated from db");
        }
        return Unit.Value;
    }
}
