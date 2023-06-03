using Packt.Shared;

//Northwind db = new();
//WriteLine($"Provider: {db.Database.ProviderName}");

//QueryingCategories();

//FilteredIncludes();

//QueryingWithLike();

//GetRandomProduct();

(int affected, int id) = AddProduct("kamppot", 4, 4.20M);

WriteLine($"Affected - {affected}\nid - {id}");

ListProducts(new int[] {id});