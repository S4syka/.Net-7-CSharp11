using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using System.Diagnostics;
using Packt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindContext injectedDb)
        {
            _logger = logger;
            db = injectedDb;
        }

        [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            HomeIndexViewModel model = new(Random.Shared.Next(1, 1001), db.Categories.ToList(), db.Products.ToList());
            return View(model);
        }

        [Route("Private")]
        [Authorize(Roles = "Administrators")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProductDetail(int? id, string alertStyle = "sucess")
        {
            ViewData["alertStyle"] = alertStyle;
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, ofr example. /Home/ProductDetail/21");
            }

            Product? model = db.Products.SingleOrDefault(p => p.ProductId == id);

            if(model is null)
            {
                return NotFound($"ProductId {id} not found.");
            }

            return View(model);
        }

        public IActionResult ModelBinding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new(thing, !ModelState.IsValid, ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage));
            
            return View(model);
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return BadRequest("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
            }

            IEnumerable<Product> model = db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No products cost more than {price:C}.");
            }
            ViewData["MaxPrice"] = price.Value.ToString("C");

            return View(model);
        }
    }
}