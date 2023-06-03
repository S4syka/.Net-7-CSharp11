using Packt.Shared;

//Northwind db = new();
//WriteLine($"Provider: {db.Database.ProviderName}");

//QueryingCategories();

//FilteredIncludes();

//QueryingWithLike();

//GetRandomProduct();

//(int affected, int id) = AddProduct("kamppot", 4, 4.20M);

//WriteLine($"Affected - {affected}\nid - {id}");

//ListProducts(new int[] {id});

WriteLine("About to delete all products whose name starts with kamp.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productNameStartsWith: "kamp");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}
