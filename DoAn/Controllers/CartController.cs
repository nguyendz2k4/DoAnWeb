using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}