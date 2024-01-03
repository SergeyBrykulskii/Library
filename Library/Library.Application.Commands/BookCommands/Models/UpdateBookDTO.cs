namespace Library.Application.Commands.BookCommands.Models;

public class UpdateBookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public DateTime RecieveDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Genre { get; set; }
    public AuthorReply AuthorReply { get; set; }
}
