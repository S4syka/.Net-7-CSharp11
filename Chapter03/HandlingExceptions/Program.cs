using static System.Console;

WriteLine("Before parsing");
Write("What is your age? ");
string? input = ReadLine(); // or use "49" in a notebook

try
{
    int age = int.Parse(input!);
    WriteLine($"You are {age} years old.");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it is either too big or small.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}

WriteLine("After parsing");
checked
{
    int max = 500;
    for (byte i = 0; i < max; i++)
    {
        WriteLine(i);
    }
}