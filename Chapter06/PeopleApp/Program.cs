using Packt.Shared;

static void Harry_Shout(object? sender, EventArgs e)
{
    if (sender == null)
    {
        return;
    }

    Person? p = sender as Person;
    if (p is null) return;

    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

Person harry = new()
{
    Name = "Harry",
    DateOfBirth = new(year: 2001, month: 3, day: 25)
};

//harry.WriteToConsole();

//// non-generic lookup collection

//System.Collections.Hashtable lookupObject = new();

//lookupObject.Add(1, "Alpha");
//lookupObject.Add(2, "Beta");
//lookupObject.Add(3, "Gamma");
//lookupObject.Add(harry, "Delta");

//// look up the value that has harry as its key
//WriteLine(format: "Key {0} has value: {1}",
// arg0: harry,
// arg1: lookupObject[harry]);

//Dictionary<int, string> lookupIntString = new();
//lookupIntString.Add(key: 1, value: "Alpha");
//lookupIntString.Add(key: 2, value: "Beta");
//lookupIntString.Add(key: 3, value: "Gamma");
////lookupIntString.Add(key: harry, value: "Delta"); //Compilation error
//lookupIntString.Add(key: 4, value: "Delta");

harry.Shout += Harry_Shout;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

delegate int DelegateWithMatchingSignature(string s);

