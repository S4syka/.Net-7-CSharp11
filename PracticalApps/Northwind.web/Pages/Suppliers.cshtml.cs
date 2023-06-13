using Microsoft.AspNetCore.Mvc; // [BindProperty], IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Packt.Shared;

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
    [BindProperty]
    public Supplier? Supplier { get; set; }

    private NorthwindContext db;

    public IEnumerable<Supplier>? Suppliers { get; set; }

    public SuppliersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";
        Suppliers = db.Suppliers.OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
    }

    public IActionResult OnPost()
    {
        if ((Supplier is not null) && ModelState.IsValid)
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page(); // return to original page
        }
    }
}