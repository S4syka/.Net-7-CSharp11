//int numberOfApples = 12;
//decimal pricePerApple = 0.31255M;

//Console.WriteLine("{0} apple costs {1:C}", numberOfApples, numberOfApples * pricePerApple);

//Console.WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");

//Console.WriteLine($"{numberOfApples} apples cost {pricePerApple
// *
// numberOfApples:C}");

//string test = $"{numberOfApples} {pricePerApple}";
//Console.WriteLine(test);
//string applesText = "Apples";
//int applesCount = 1234;
//string bananasText = "Bananas";
//int bananasCount = 56789;

//Console.WriteLine(
// format: "{0,-10} {1,6}",
// arg0: "Name",
// arg1: "Count");
//Console.WriteLine(
// format: "{0,-10} {1,6:N0}",
// arg0: applesText,
// arg1: applesCount);
//Console.WriteLine(
// format: "{0,-10} {1,6:N0}",
// arg0: bananasText,
// arg1: bananasCount);

//Console.WriteLine("{0, -15} {1, 20}", "saxeli", "gvari");
//Console.WriteLine("{0, -15} {1, 20}", "erekle", "xomski");
//Console.WriteLine("{0, -15} {1, 20}", "tedo", "nadareishvili");

//Console.Write("Type your first name and press ENTER: ");
//string firstName = Console.ReadLine()!;

//Console.Write("Type your age and press ENTER: ");
//string? age = Console.ReadLine();
//WriteLine($"Hello {firstName}, you look good for {age}.");

Write("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
 arg0: key.Key,
 arg1: key.KeyChar,
 arg2: key.Modifiers);