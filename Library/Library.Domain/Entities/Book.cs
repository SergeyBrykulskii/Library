﻿namespace Library.Domain.Entities;

public class Book : IEntity
{
    public Book() { }
    public Book(Guid id, string title, string isbn, string description, DateTime receiveDate,
                DateTime returnDate, Author author, string genre)
    {
        Id = id;
        Title = title;
        ISBN = isbn;
        Description = description;
        RecieveDate = receiveDate;
        ReturnDate = returnDate;
        Author = author;
        Genre = genre;
    }

    public Book(Guid id, string title, string iSBN, string description, DateTime recieveDate,
                DateTime returnDate, Guid authorId, string genre)
    {
        Id = id;
        Title = title;
        ISBN = iSBN;
        Description = description;
        RecieveDate = recieveDate;
        ReturnDate = returnDate;
        AuthorId = authorId;
        Genre = genre;
    }

    public Book(Guid id, string title, string isbn, string description, Guid authorId, string genre)
    {
        Id = id;
        Title = title;
        ISBN = isbn;
        Description = description;
        AuthorId = authorId;
        Genre = genre;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public DateTime RecieveDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public string Genre { get; set; }
}