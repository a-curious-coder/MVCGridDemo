using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCGridProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using NonFactors.Mvc.Grid; // Add this line

namespace MVCGridProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<Product> _products;
    private static List<Product> _batchedProducts;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        if (_batchedProducts == null)
        {
            _batchedProducts = GenerateBatchedProductsSync();
        }
    }

    // Remove the following method:
    // public IActionResult Index()
    // {
    //     var grid = new Grid<Product>(GetYourData())
    //         .WithPaging(5) // Set default page size to 5
    //         // ... other grid configurations ...
    //         ;
    //
    //     return View(grid);
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> BasicGrid()
    {
        if (_products == null)
        {
            _products = await GenerateProductsAsync();
        }
        return View(_products);
    }

    public async Task<IActionResult> AdvancedGrid()
    {
        if (_products == null)
        {
            _products = await GenerateProductsAsync();
        }
        return View(_products);
    }

    public async Task<IActionResult> CustomGrid()
    {
        if (_products == null)
        {
            _products = await GenerateProductsAsync();
        }
        return View(_products);
    }

    public IActionResult AjaxGrid()
    {
        return View();
    }

    public async Task<IActionResult> GetAjaxGridData()
    {
        if (_products == null)
        {
            _products = await GenerateProductsAsync();
        }
        return PartialView("_AjaxGrid", _products);
    }

    public async Task<IActionResult> GroupedGrid()
    {
        if (_products == null)
        {
            _products = await GenerateProductsAsync();
        }
        return View(_products);
    }

    public IActionResult BatchedAjaxGrid()
    {
        return View();
    }

    [HttpGet]
    public ActionResult GetBatchedAjaxGridData()
    {
        if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            // Simulate a short delay for each batch retrieval
            Thread.Sleep(200);

            return PartialView("_BatchedAjaxGrid", _batchedProducts.AsQueryable());
        }

        return View();
    }

    private static async Task<List<Product>> GenerateProductsAsync()
    {
        // Simulate a long-running database query
        await Task.Delay(25000); // 25 seconds delay

        var random = new Random(42); // Seed for consistent randomness
        var categories = new[] { "Electronics", "Clothing", "Books", "Home & Garden", "Toys" };
        var products = new List<Product>();

        for (int i = 1; i <= 5000; i++)
        {
            products.Add(new Product
            {
                Id = i,
                Name = $"Product {i}",
                Category = categories[random.Next(categories.Length)],
                Price = Math.Round((decimal)random.NextDouble() * 1000, 2),
                Stock = random.Next(0, 1000),
                CreatedDate = DateTime.Now.AddDays(-random.Next(1, 1000)),
                IsAvailable = random.Next(2) == 0
            });
        }

        return products;
    }

    private static List<Product> GenerateBatchedProductsSync()
    {
        var random = new Random(42); // Seed for consistent randomness
        var categories = new[] { "Electronics", "Clothing", "Books", "Home & Garden", "Toys" };
        var products = new List<Product>();

        for (int i = 1; i <= 5000; i++)
        {
            products.Add(new Product
            {
                Id = i,
                Name = $"Product {i}",
                Category = categories[random.Next(categories.Length)],
                Price = Math.Round((decimal)random.NextDouble() * 1000, 2),
                Stock = random.Next(0, 1000),
                CreatedDate = DateTime.Now.AddDays(-random.Next(1, 1000)),
                IsAvailable = random.Next(2) == 0
            });
        }

        return products;
    }
}
