using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class Shop : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
