using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

internal partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new ())
        {
            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

            if((categories is null) || (!categories.Any()))
            {
                Fail("No categories found");
                return;
            } 

            foreach(Category c in categories)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");
            }
        }
    }
}
