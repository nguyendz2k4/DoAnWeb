using DoAn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class LoginController : Controller
    {
		
		private UserManager<AppUserModel> _userManage;
        private SignInManager<AppUserModel> _signInManager;
        public LoginController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManager) {
            _userManage = userManager;
            _signInManager = signInManager;
        }
		[Route("[controller]/[action]")]
		public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> login()
        {
            return View();
        }
    }
}
