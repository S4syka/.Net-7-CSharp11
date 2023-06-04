using Microsoft.EntityFrameworkCore;
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
}
