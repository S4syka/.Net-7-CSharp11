using System.Text.Json.Serialization;

public class Book
{
    public string Title { get; set; }
    public string? Author { get; set; }

    public Book(string title)
    {
        Title = title;
    }

    [JsonInclude] // include this field
    public DateTime PublishDate;

    [JsonInclude] // include this field
    public DateTimeOffset Created;

    public ushort Pages;
}