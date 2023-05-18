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