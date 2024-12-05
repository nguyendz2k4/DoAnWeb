using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Controllers
{
    public class CategoryController : Controller
    {
        private readonly APSWeb1Context _apsweb1Context;

        public CategoryController(APSWeb1Context context)
        {
            _apsweb1Context = context;
        }

        // Action để hiển thị sản phẩm theo danh mục
        public async Task<IActionResult> Index(string Name = "")
        {
            // Kiểm tra nếu không có giá trị Name thì trả về tất cả danh mục
            if (string.IsNullOrEmpty(Name))
            {
                var allCategories = await _apsweb1Context.TblProductCategoys.ToListAsync();
                return View("AllCategories", allCategories);
            }

            // Tìm danh mục theo tên
            var category = await _apsweb1Context.TblProductCategoys
                                                .Where(c => c.Name == Name)
                                                .FirstOrDefaultAsync();

            // Nếu không tìm thấy danh mục thì trả về thông báo lỗi
            if (category == null)
            {
                ViewBag.ErrorMessage = "Danh mục không tồn tại!";
                return View("Error");
            }

            // Lấy danh sách sản phẩm thuộc danh mục này
            var productsByCategory = await _apsweb1Context.TblProducts
                                                          .Where(p => p.CateId == category.CateId)
                                                          .ToListAsync();

            // Nếu không có sản phẩm trong danh mục thì hiển thị thông báo
            if (productsByCategory.Count == 0)
            {
                ViewBag.ErrorMessage = "Không có sản phẩm trong danh mục này!";
                return View("Error");
            }

            // Trả về view với danh sách sản phẩm
            return View(productsByCategory);
        }

        // Action để xử lý khi bấm vào tên danh mục
        public async Task<IActionResult> ViewCategory(string Name)
        {
            // Tìm danh mục theo tên
            var category = await _apsweb1Context.TblProductCategoys
                                                .Where(c => c.Name == Name)
                                                .FirstOrDefaultAsync();

            // Nếu không tìm thấy danh mục thì trả về trang lỗi
            if (category == null)
            {
                ViewBag.ErrorMessage = "Danh mục không tồn tại!";
                return View("Error");
            }

            // Lấy danh sách sản phẩm thuộc danh mục này
            var productsByCategory = await _apsweb1Context.TblProducts
                                                          .Where(p => p.CateId == category.CateId)
                                                          .ToListAsync();

            // Nếu không có sản phẩm nào thì trả về thông báo
            if (productsByCategory.Count == 0)
            {
                ViewBag.ErrorMessage = "Không có sản phẩm nào trong danh mục này!";
                return View("Error");
            }

            // Trả về view với danh sách sản phẩm
            return View("Index", productsByCategory);
        }
    }
}
