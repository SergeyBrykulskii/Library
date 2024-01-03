namespace Library.Application.Commands.BookCommands.Models;

public class CreateBookDTO
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public AuthorReply AuthorReply { get; set; }
}
