using Packt.Shared;

Person bob = new();
//WriteLine(bob.ToString());

bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1999, 1, 31);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = (WondersOfTheAncientWorld)18;

//WriteLine("{0} was born on {1:dddd, d MMMM yyyy}.", bob.Name, bob.DateOfBirth);
//WriteLine("{0}'s favorite Wonder is {1}. Its integer is {2}", bob.Name, bob.FavoriteAncientWonder, (int)bob.FavoriteAncientWonder);
//WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}"); bob.Children.Add(new Person { Name = "Alfred" }); // C# 3.0 and later
bob.Children.Add(new() { Name = "Zoe" }); // C# 9.0 and later

//WriteLine($"{bob.Name} has {bob.Children.Count} children:");
//for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
//{
//    WriteLine($"> {bob.Children[childIndex].Name}");
//}

Person alice = new()
{
    Name = "Alice Jones",
    DateOfBirth = new(1998, 3, 7) // C# 9.0 or later
};

//WriteLine("{0} was born on {1:dd MMM yy}", alice.Name, alice.DateOfBirth);

BankAccount.InterestRate = 0.012M; // store a shared value
BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
 arg0: jonesAccount.AccountName,
 arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
 arg0: gerrierAccount.AccountName,
 arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

(string? name, DateTime dob, WondersOfTheAncientWorld fav) = bob;

WriteLine(fav);

int number = 5; // change to -1 to make the exception handling 
try
{
 WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
}