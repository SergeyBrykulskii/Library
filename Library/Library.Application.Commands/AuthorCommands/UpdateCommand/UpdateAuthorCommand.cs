using MediatR;

namespace Library.Application.Commands.AuthorCommands.UpdateCommand;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public UpdateAuthorDTO updateAuthorDTO { get; set; }
}
