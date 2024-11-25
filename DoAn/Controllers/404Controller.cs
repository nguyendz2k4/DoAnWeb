using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class _404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}