using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
