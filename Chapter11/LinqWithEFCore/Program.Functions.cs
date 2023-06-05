using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Packt.Shared;

partial class Program
{
    static void FilterAndSort()
    {
        SectionTitle("Filter and sort");

        using (Northwind db = new())
        {
            DbSet<Product> allproducts = db.Products;

            IQueryable<Product> filteredProducts = allproducts.Where(p => p.UnitPrice < 10M);
            IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(p => p.UnitPrice);
            WriteLine(sortedAndFilteredProducts.ToQueryString());

            var projectedProducts = sortedAndFilteredProducts
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.UnitPrice
                });
            WriteLine(projectedProducts.ToQueryString());

            WriteLine("All products with price less than $10");
            foreach (var p in projectedProducts)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
            }
        }
    }

    static void JoinCategoriesAndProducts()
    {
        SectionTitle("Join categories and products.");

        using (Northwind db = new())
        {
            var queryJoin = db.Categories
                .Join(db.Products, c => c.CategoryId, p => p.CategoryId,
                (c, p) => new { c.CategoryName, p.ProductName, p.ProductId });

            Console.WriteLine(queryJoin.ToQueryString());

            foreach (var item in queryJoin)
            {
                Console.WriteLine("{0}: {1} is in {2}.", item.ProductId, item.ProductName, item.CategoryName);
            }
        }
    }

    static void GroupJoinCategoriesAndProducts()
    {
        SectionTitle("Group join categories and products.");

        using (Northwind db = new())
        {
            var queryGroup = db.Categories.AsEnumerable().GroupJoin(db.Products, c => c.CategoryId, p => p.CategoryId,
                (c, matchingProducts) => new { c.CategoryName, Products = matchingProducts.OrderBy(p => p.ProductName) });

            foreach (var category in queryGroup)
            {
                WriteLine("{0} has {1} products.",
                    arg0: category.CategoryName,
                    arg1: category.Products.Count());

                foreach (var product in category.Products)
                {
                    WriteLine($" {product.ProductName}");
                }
            }
        }
    }

    static void OutputTableOfProducts(Product[] products, int currentPage, int totalPages)
    {
        string line = new('-', count: 73);
        string lineHalf = new('-', count: 30);

        WriteLine(line);
        WriteLine("{0,4} {1,-40} {2,12} {3,-15}", "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);

        foreach (Product p in products)
        {
            WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}",
            p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
        }

        WriteLine("{0} Page {1} of {2} {3}", lineHalf, currentPage + 1, totalPages + 1, lineHalf);
    }

    static void OutputPageOfProducts(IQueryable<Product> products, int pageSize, int currentPage, int totalPages)
    {
        // We must order data before skipping and taking to ensure
        // the data is not randomly sorted in each page.
        var pagingQuery = products.OrderBy(p => p.ProductId)
                            .Skip(currentPage * pageSize)
                            .Take(pageSize);

        SectionTitle(pagingQuery.ToQueryString());

        OutputTableOfProducts(pagingQuery.ToArray(), currentPage, totalPages);
    }

    static void PagingProducts()
    {
        SectionTitle("Paging products");
        using (Northwind db = new())
        {
            int pageSize = 10;
            int currentPage = 0;
            int productCount = db.Products.Count();
            int totalPages = productCount / pageSize;
            while (true)
            {
                OutputPageOfProducts(db.Products, pageSize, currentPage, totalPages);
                Write("Press <- to page back, press -> to page forward, any key to exit.");

                ConsoleKey key = ReadKey().Key;
                if (key == ConsoleKey.LeftArrow)
                    if (currentPage == 0)
                        currentPage = totalPages;
                    else
                        currentPage--;
                else if (key == ConsoleKey.RightArrow)
                    if (currentPage == totalPages)
                        currentPage = 0;
                    else
                        currentPage++;
                else
                    break; // out of the while loop.
                WriteLine();
            }
        }
    }
}