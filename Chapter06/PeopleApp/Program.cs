using Packt.Shared;

//Person harry = new()
//{
//    Name = "Harry",
//    DateOfBirth = new(year: 2001, month: 3, day: 25)
//};

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

//harry.Shout += Harry_Shout;

//harry.Poke();
//harry.Poke();
//harry.Poke();
//harry.Poke();

//Person?[] people =
//{
// null,
// new() { Name = "Simon" },
// new() { Name = "Jenny" },
// new() { Name = "Adam" },
// new() { Name = null },
// new() { Name = "Richard" }
//};

//OutputPeopleNames(people, "Initial list of people:");

//Array.Sort(people, new PersonComparer());

//OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");

//Employee john = new()
//{
//    Name = "John Jones",
//    DateOfBirth = new(year: 1990, month: 7, day: 28)
//};
////john.WriteToConsole();

//john.EmployeeCode = "JJ001";
//john.HireDate = new(year: 2014, month: 11, day: 23);
//WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

string email1 = "ekebichi@gmail.com";
string email2 = "akaki&test.com";

WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email1,
 arg1: StringExtensions.IsValidEmail(email1));
WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email2,
 arg1: StringExtensions.IsValidEmail(email2));


WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email1,
 arg1: email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email2,
 arg1: email2.IsValidEmail());