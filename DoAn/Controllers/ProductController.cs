using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Controllers
{
    public class ProductController : Controller
    {
        private readonly APSWeb1Context _apsweb1Context;

        public ProductController(APSWeb1Context context)
        {
            _apsweb1Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null)
                return RedirectToAction("Index");

            // Lấy sản phẩm theo ID
            var product = await _apsweb1Context.TblProducts
                .Where(p => p.ProductId == Id)
                .FirstOrDefaultAsync();

            if (product == null)
                return NotFound();

            // Lấy danh mục sản phẩm tương ứng
            var category = await _apsweb1Context.TblProductCategoys
                .Where(c => c.CateId == product.CateId)
                .FirstOrDefaultAsync();

            // Truyền dữ liệu vào ViewBag
            ViewBag.Product = product;
            ViewBag.Category = category;

            return View();
        }

    }
}
