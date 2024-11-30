using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var products = _apsweb1Context.TblProducts.ToList();
            //var products = _apsweb1Context.TblProducts.Where(p => p.Name == "").ToList();
            return View(products);
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
