using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly APSWeb1Context _apsweb1Context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(APSWeb1Context context,ILogger<HomeController> logger)
        {
            _logger = logger;
            _apsweb1Context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _apsweb1Context.TblProducts.ToListAsync();
            var suppliers = await _apsweb1Context.TblSuppliers.ToListAsync();
            ViewBag.Products = products;
            ViewBag.Suppliers = suppliers;

            return View();
        }
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
