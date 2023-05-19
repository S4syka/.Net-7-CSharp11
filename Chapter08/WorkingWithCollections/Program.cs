using System.Collections.Immutable;

// Simple syntax for creating a list and adding three items
List<string> cities = new();

cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

/* Alternative syntax that is converted by the compiler into
 the three Add method calls above
List<string> cities = new()
 { "London", "Paris", "Milan" }; */
/* Alternative syntax that passes an 
 array of string values to AddRange method
List<string> cities = new(); 
cities.AddRange(new[] { "London", "Paris", "Milan" }); */

Output("Initial list", cities);
Console.WriteLine($"The first city is {cities[0]}.");
Console.WriteLine($"The last city is {cities[cities.Count - 1]}.");

cities.Insert(0, "Sydney");
Output("After inserting Sydney at index 0", cities);

cities.RemoveAt(1);
cities.Remove("Milan");
Output("After removing two cities", cities);



Dictionary<string, string> keywords = new();

// add using named parameters
keywords.Add(key: "int", value: "32-bit integer data type");
// add using positional parameters
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

/* Alternative syntax; compiler converts this to calls to Add method
Dictionary<string, string> keywords = new()
{
 { "int", "32-bit integer data type" },
 { "long", "64-bit integer data type" },
 { "float", "Single precision floating point number" },
}; */
/* Alternative syntax; compiler converts this to calls to Add method
 Dictionary<string, string> keywords = new()
{
 ["int"] = "32-bit integer data type",
 ["long"] = "64-bit integer data type",
 ["float"] = "Single precision floating point number", // last comma is 
optional
}; */

Output("Dictionary keys:", keywords.Keys);
Output("Dictionary values:", keywords.Values);
Console.WriteLine("Keywords and their definitions");

foreach (KeyValuePair<string, string> item in keywords)
{
    Console.WriteLine($" {item.Key}: {item.Value}");
}

// look up a value using a key
string key = "long";
Console.WriteLine($"The definition of {key} is {keywords[key]}");

Queue<string> coffee = new();

coffee.Enqueue("Damir"); // front of queue
coffee.Enqueue("Andrea");
coffee.Enqueue("Ronald");
coffee.Enqueue("Amin");
coffee.Enqueue("Irina"); // back of queue
Output("Initial queue from front to back", coffee);

// server handles next person in queue
string served = coffee.Dequeue();
Console.WriteLine($"Served: {served}.");

// server handles next person in queue
served = coffee.Dequeue();
Console.WriteLine($"Served: {served}.");
Output("Current queue from front to back", coffee);

Console.WriteLine($"{coffee.Peek()} is next in line.");
Output("Current queue from front to back", coffee);

PriorityQueue<string, int> vaccine = new();

vaccine.Enqueue("Pamela", 1); // my mum (70s)
vaccine.Enqueue("Rebecca", 3); // my niece (teens)
vaccine.Enqueue("Juliet", 2); // my sister (40s)
vaccine.Enqueue("Ian", 1); // my dad (70s)

OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

Console.WriteLine("Adding Mark to queue with priority 2");
vaccine.Enqueue("Mark", 2); // me (40s)

Console.WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

ImmutableList<string> immutableCities = cities.ToImmutableList();
ImmutableList<string> newList = immutableCities.Add("Gori");

Output("Immutable list", immutableCities);
Output("New list", newList);