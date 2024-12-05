using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAn.Controllers
{
    public class Shop : Controller
    {
        private readonly APSWeb1Context _apsweb1Context;

        public Shop(APSWeb1Context context)
        {
            _apsweb1Context = context;
        }
        public IActionResult Index()
        {
            var products = _apsweb1Context.TblProducts.ToList();
            return View(products);
        }
    }
}
