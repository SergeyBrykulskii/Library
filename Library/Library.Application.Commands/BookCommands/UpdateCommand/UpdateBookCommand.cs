using Library.Application.Commands.BookCommands.Models;
using MediatR;

namespace Library.Application.Commands.BookCommands.UpdateCommand;

public class UpdateBookCommand : IRequest<Unit>
{
    public UpdateBookDTO updateBookDTO { get; set; }
}
