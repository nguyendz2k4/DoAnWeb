using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Repository
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly APSWeb1Context _context;
        public CategoriesViewComponent(APSWeb1Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.TblProductCategoys.ToListAsync());
    }
}
