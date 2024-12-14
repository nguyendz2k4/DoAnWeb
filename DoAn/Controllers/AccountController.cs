using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
