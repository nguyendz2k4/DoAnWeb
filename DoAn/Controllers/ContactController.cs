using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class ContactController : Controller
    {
        private readonly APSWeb1Context _context;
        public ContactController(APSWeb1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Detail, bool Status)
        {
            try
            {
                TblContac contac = new TblContac();
                contac.Name = Name;
                contac.Detail = Detail;
                _context.Add(contac);
                _context.SaveChangesAsync();
                return Json(new { Status = true });
            }
            catch
            {
                return Json(new { Status = false });
            }
        }
    }
}
