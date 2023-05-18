partial class Program
{
    static void Output(string title, IEnumerable<string> collection)
    {
        Console.WriteLine(title);
        foreach (string item in collection)
        {
            Console.WriteLine($" {item}");
        }
    }
}