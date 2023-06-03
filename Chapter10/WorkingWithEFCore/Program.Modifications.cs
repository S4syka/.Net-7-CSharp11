using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal partial class Program
{
    static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using (Northwind db = new Northwind())
        {
            if (db.Products == null || !db.Products.Any())
            {
                Fail("There are no products in the table!.");
                return;
            }

            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
                "Id", "Product Name", "Cost", "Stock", "Disc.");

            ConsoleColor previousColor = Console.ForegroundColor;

            foreach(Product p in db.Products)
            {
                if (productIdsToHighlight != null && productIdsToHighlight.Contains(p.ProductId))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |", 
                    p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);

                ForegroundColor = previousColor;
            }
        }
    }

    static (int affected, int productId) AddProduct(string productName, int categoryId, decimal? price)
    {
        using (Northwind db = new Northwind())
        {
            if (db.Products == null) return (0, 0);

            Product p = new() { CategoryId = categoryId, Cost = price, ProductName = productName, Stock = 777 };

            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

            return (affected, p.ProductId);
        }
    }
}

