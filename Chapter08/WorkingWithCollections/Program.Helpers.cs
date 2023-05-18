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

    static void OutputPQ<TElement, TPriority>(string title,  IEnumerable<(TElement Element, TPriority priority)> collection)
    {
        Console.WriteLine(title);

        foreach(var item in collection)
        {
            Console.WriteLine($" {item.Item1}: {item.Item2}");
        }
    }
}