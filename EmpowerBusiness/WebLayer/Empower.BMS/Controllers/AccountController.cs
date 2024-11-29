using Microsoft.AspNetCore.Mvc;

namespace Empower.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region  - Login Page
        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region  - Register Page
        public IActionResult Register()
        {
            return View();
        }

        #endregion

        #region  - Forget Password Page
        public IActionResult ForgetPassword()
        {
            return View();
        }

        #endregion
    }
}
