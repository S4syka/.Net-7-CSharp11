using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;

internal partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            IQueryable<Category>? categories;
            // = db.Categories;
            // .Include(c => c.Products);

            db.ChangeTracker.LazyLoadingEnabled = false;

            Write("Enable eager loading? (Y/N): ");
            bool eagerLoading = (ReadKey(intercept: true).Key == ConsoleKey.Y);
            bool explicitLoading = false;
            
            WriteLine();
            if (eagerLoading)
            {
                categories = db.Categories?.Include(c => c.Products);
            }
            else
            {
                categories = db.Categories;
                Write("Enable explicit loading? (Y/N): ");
                explicitLoading = (ReadKey(intercept: true).Key == ConsoleKey.Y);
                WriteLine();
            }

            foreach (Category c in categories!)
            {
                if (explicitLoading)
                {
                    Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                    ConsoleKeyInfo key = ReadKey(intercept: true);
                    WriteLine();
                    if (key.Key == ConsoleKey.Y)
                    {
                        CollectionEntry<Category, Product> products =
                        db.Entry(c).Collection(c2 => c2.Products);
                        if (!products.IsLoaded) products.Load();
                    }
                }

                Console.WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");
            }
        }
    }

    static void FilteredIncludes()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products with a minimum number of units in stock.");

            string? input;
            int stock;

            do
            {
                Write("Enter a minimum for units in stock: ");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));

            IQueryable<Category>? categories = db.Categories?.TagWith("Products with big enough stock.").Include(c => c.Products.Where(p => p.Stock >= stock));

            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found!");
                return;
            }

            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

                foreach (Product p in c.Products)
                {
                    if (p.Stock >= stock)
                    {
                        Console.WriteLine($"{p.ProductName} has {p.Stock} units.");
                    }
                }
            }
        }
    }

    static void QueryingWithLike()
    {
        using (Northwind db = new())
        {
            SectionTitle("Pattern matching with LIKE.");

            Write("Enter part of a product name: ");
            string? input = ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Fail("You did not enter part of a product name.");
                return;
            }

            IQueryable<Product>? products = db.Products?.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

            if ((products == null) || (!products.Any()))
            {
                Fail("No products found.");
                return;
            }

            foreach (Product p in products)
            {
                WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                p.ProductName, p.Stock, p.Discontinued);
            }
        }
    }

    static void GetRandomProduct()
    {
        using (Northwind db = new())
        {
            SectionTitle("Get a random product.");

            int? rowCount = db.Products?.Count();

            IQueryable<Product>? products = db.Products;

            if ((products == null) || (!products.Any()) || rowCount == null)
            {
                Fail("No products found.");
                return;
            }

            Product? p = products?.FirstOrDefault(p => p.ProductId == (int)(EF.Functions.Random() * rowCount));

            if (p == null)
            {
                Fail("Product not found.");
                return;
            }

            Console.WriteLine($"Random product: {p.ProductId} {p.ProductName}");
        }
    }


}
