using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using DoAn.Repository;
using DoAn.Models.ViewModels;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        private readonly APSWeb1Context _context;
        public CartController(APSWeb1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItemModel> cartItem = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItem,
                GrandTotal = cartItem.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }

        public async Task<IActionResult> Add(int ProductId)
        {
            TblProduct product = await _context.TblProducts.FindAsync(ProductId);

            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            CartItemModel cartItem = cart.Where(c=>c.ProductId == ProductId).FirstOrDefault();

            if (cartItem != null)
            {
                cart.Add(new CartItemModel(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);


            return RedirectToAction(Request.Headers["Referer"].ToString());

        }
    }
}
