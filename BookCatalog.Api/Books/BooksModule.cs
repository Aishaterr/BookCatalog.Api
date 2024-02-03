using BookCatalog.Application.Books;
using BookCatalog.Application.Books.CreateBooks;
using BookCatalog.Application.Books.DeleteBook;
using BookCatalog.Application.Books.GetBook;
using BookCatalog.Application.Books.GetBooks;
using BookCatalog.Application.Books.UpdateBook;
using BookCatalog.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Api.Book;

public static class BooksModule
{
    public static void RegisterBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/books/list", async ([FromBody] BookListRequestDTO request, ISender sender) =>
        {
            Result<List<BookResponseDTO>> result = await sender.Send(new GetBooksQuery(
                request.Filters,
                request.Paging));

            return Results.Ok(result.Value);
        });
        //.Accepts<BookListRequestDTO>(contentType: "application/json")
        //.Produces<Result<BookListRequestDTO>>(statusCode: 200);

        app.MapGet("/books/get", async (long bookId, ISender sender) =>
        {
            Result<BookResponseDTO> result = await sender.Send(new GetBookQuery(bookId));

            return Results.Ok(result.Value);
        });

        app.MapPost("/books/create", async ([FromBody] CreateBookDTO request, ISender sender) =>
        {
            Result result = await sender.Send(new CreateBookCommand(
                request.Title, 
                request.Description, 
                DateTime.UtcNow, 
                request.CategoryId));

            return Results.Ok(result);
        });

        app.MapPut("/books/update", async ([FromBody] UpdateBookDTO request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateBookCommand(request));

            return Results.Ok(result);
        });

        app.MapDelete("books/delete", async (long bookId, ISender sender) =>
        {
            Result result = await sender.Send(new DeleteBookCommand(bookId));

            return Results.Ok(result);
        });

    }
}
