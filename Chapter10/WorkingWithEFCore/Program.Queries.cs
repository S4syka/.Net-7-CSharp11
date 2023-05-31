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

            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));

            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found!");
                return;
            }

            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

                foreach(Product p in c.Products)
                {
                    if (p.Stock >= stock)
                    {
                        Console.WriteLine($"{p.ProductName} has {p.Stock} units.");
                    }
                }
            }
        }
    }
}
