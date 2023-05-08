namespace Packt.Shared;

public partial class Person
{
    public string? Name;

    public DateTime DateOfBirth;

    public WondersOfTheAncientWorld FavoriteAncientWonder;

    public WondersOfTheAncientWorld BucketList;

    public List<Person> Children = new();

    public const string Species = "Homo Sapiens";

    public readonly string HomePlanet = "Earth";

    public readonly DateTime Instantiated;

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}.";
    }

    public void Deconstruct(out string? name, out DateTime dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = DateOfBirth;
        fav = FavoriteAncientWonder;
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }
}
