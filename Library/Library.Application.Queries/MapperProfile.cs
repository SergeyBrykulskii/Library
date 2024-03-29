﻿using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Domain.Entities;

namespace Library.Application.Queries;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, AuthorDTO>()
           .ForMember("Id",
               opt => opt.MapFrom(author => author.Id))
           .ForMember("FirstName",
               opt => opt.MapFrom(author => author.FirstName))
           .ForMember("Surname",
               opt => opt.MapFrom(author => author.Surname)).ReverseMap();

        CreateMap<Book, BookDTO>();

        CreateMap<Book, BooksListDTO>()
            .ForMember(bookDto => bookDto.Id, opt => opt.MapFrom(book => book.Id))
            .ForMember(bookDto => bookDto.Title, opt => opt.MapFrom(book => book.Title))
            .ForMember(bookDto => bookDto.Description, opt => opt.MapFrom(book => book.Description))
            .ForMember(bookDto => bookDto.AuthorReply, opt => opt.MapFrom(book => book.Author))
            .ForMember(bookDto => bookDto.Genre, opt => opt.MapFrom(book => book.Genre));
    }
}
