using MediatR;

namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;

public class GetBookByIdQuerie : IRequest<BookDTO>
{
    public Guid Id { get; set; }
}
