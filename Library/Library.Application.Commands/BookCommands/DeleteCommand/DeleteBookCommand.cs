using MediatR;

namespace Library.Application.Commands.BookCommands.DeleteCommand;

public class DeleteBookCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
