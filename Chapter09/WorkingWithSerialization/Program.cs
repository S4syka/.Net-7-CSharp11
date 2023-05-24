using Packt.Shared; // Person 
using System.Xml.Serialization;

using static System.Environment;
using static System.IO.Path;

// create an object graph
List<Person> people = new()
{
     new(30000M)
     {
         FirstName = "Alice",
         LastName = "Smith",
         DateOfBirth = new(year: 1974, month: 3, day: 14)
     },
     new(40000M)
     {
         FirstName = "Bob",
         LastName = "Jones",
         DateOfBirth = new(year: 1969, month: 11, day: 23)
     },
     new(20000M)
     {
         FirstName = "Charlie",
         LastName = "Cox",
         DateOfBirth = new(year: 1984, month: 5, day: 4),
         Children = new()   
         {
             new(0M)
             {
                 FirstName = "Sally",
                 LastName = "Cox",
                 DateOfBirth = new(year: 2012, month: 7, day: 12)
             }
         }
     }
};

XmlSerializer xs = new(people.GetType());

string path = Combine(CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

Console.WriteLine("Written {0:N0} bytes of XML to {1}", new FileInfo(path).Length, path);
Console.WriteLine();
Console.WriteLine(File.ReadAllText(path));

Console.WriteLine();
Console.WriteLine("Deserializing XML files");

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            Console.WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
        }
    }
}