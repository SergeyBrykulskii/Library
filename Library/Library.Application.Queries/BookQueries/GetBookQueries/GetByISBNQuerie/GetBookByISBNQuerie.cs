using MediatR;

namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByISBNQuerie;

public class GetBookByISBNQuerie : IRequest<BookDTO>
{
    public string ISBN { get; set; }
}
