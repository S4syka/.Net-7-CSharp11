using System.Data;

partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }

    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        return amount * GetTaxPercentage(twoLetterRegionCode);
    }

    static decimal GetTaxPercentage(string twoLetterRegionCode) =>
        twoLetterRegionCode.ToUpper() switch
        {
            "CH" => 0.08M,
            "DK" or "NO" => 0.25M,
            "GB" or "FR" => 0.2M,
            "HU" => 0.27M,
            "OR" or "AK" or "MT" => 0.0M,
            "ND" or "WI" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M,
            _ => 0.06M
        };

    static string CardinalToOrdinal(int number) =>
        (number % 100) switch
        {
            11 => $"{number}th",
            12 => $"{number}th",
            13 => $"{number}th",
            _ => (number % 10) switch
            {
                1 => $"{number}st",
                2 => $"{number}nd",
                3 => $"{number}rd",
                _ => $"{number}th"
            }
        };

    static void RunCardinalToOrdinal(uint count = 50)
    {
        for(int i = 1; i <= count; i++)
        {
            Console.WriteLine(CardinalToOrdinal(i));
        }
    }

    /// <summary>
    /// Pass a 16-byte integer and it will be converted to its factorial.
    /// </summary>
    /// <param name="amount">Any integer number.</param>
    /// <returns>Factorial of the given input.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    static decimal Factorial(decimal amount) =>
        amount switch
        {
            0 or 1 => 1,
            > 1 => Factorial(amount - 1) * amount,
            _ => throw new ArgumentOutOfRangeException(message: "number is negative, hence we cant calculate factorial", paramName: nameof(amount))
        };

    /// <summary>
    /// Pass a 32-bit integer i and it will be converted to i-th fibonacci number
    /// </summary>
    /// <param name="term">Index of number in fibonacci sequence </param>
    /// <returns>Fibonacci number</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    static int FibFunctional(int term) =>
        term switch
        {
            < 0 => throw new ArgumentOutOfRangeException(message: $"Given argument should be positive and it is {term}", paramName: nameof(term)),
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2)
        };
}