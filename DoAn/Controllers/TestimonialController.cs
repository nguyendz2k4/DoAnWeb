using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoAn.Controllers
{
    public class TestimonialController : Controller
    {
        public readonly APSWeb1Context _apsweb1Context;
        public TestimonialController(APSWeb1Context context) {
            _apsweb1Context = context;
        }
        public IActionResult Index()
        {
            var suppliers = _apsweb1Context.TblSuppliers.ToList();
            return View(suppliers);
        }
    }
}
