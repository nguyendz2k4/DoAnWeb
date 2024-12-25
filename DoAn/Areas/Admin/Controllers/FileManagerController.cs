using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Admin")]
        [Route("/Admin/FileManager/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
