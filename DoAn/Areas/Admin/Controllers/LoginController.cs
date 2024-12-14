using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
