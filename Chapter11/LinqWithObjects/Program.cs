//string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

//SectionTitle("Deffered execution");

//var query1 = names
//    ////.Where(NameLongerThanFour)
//    .OrderBy(name => name.Length)
//    .ThenBy(name => name);

//var query2 = names
//    .Order();

//foreach(var item in query1)
//{
//    Console.WriteLine(item);
//}

SectionTitle("Filtering by type");
List<Exception> exceptions = new()
{
 new ArgumentException(),
 new SystemException(),
 new IndexOutOfRangeException(),
 new InvalidOperationException(),
 new NullReferenceException(),
 new InvalidCastException(),
 new OverflowException(),
 new DivideByZeroException(),
 new ApplicationException()
};

var arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException>();

foreach (var item in arithmeticExceptionsQuery)
{
    Console.WriteLine(item);
}


