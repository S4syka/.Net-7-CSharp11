using Microsoft.EntityFrameworkCore;
using Packt.Shared;

internal partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found");
                return;
            }

            foreach (Category c in categories)
            {
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
