using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
