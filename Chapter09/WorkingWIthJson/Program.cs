using System.Linq.Expressions;
using System.Text.Json; // JsonSerializer

using static System.Environment;
using static System.IO.Path;

Book mybook = new("Red and Black")
{
    Author = "Stendhal",
    PublishDate = DateTime.Now,
    Pages = 42069,
    Created = DateTimeOffset.Now
};

JsonSerializerOptions options = new()
{
    IncludeFields = true,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string filePath = Combine(CurrentDirectory, "mybook.json");

using (Stream FileStream = File.Create(filePath))
{
    JsonSerializer.Serialize<Book>(FileStream, mybook, options);
}

Console.WriteLine("Written {0:N0} bytes to JSON to {1}", new FileInfo(filePath).Length, filePath);

Console.WriteLine(File.ReadAllText(filePath));