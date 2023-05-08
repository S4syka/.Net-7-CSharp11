using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;

public class Book
{
    public required string? Isbn { get; set; }

    public required string? Title { get; set; }

    public string? Author { get; set; }

    public int PageCount { get; set; }

    [SetsRequiredMembers]
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}
