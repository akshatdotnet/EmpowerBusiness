using Microsoft.AspNetCore.Mvc;

namespace Empower.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult UserManage()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }


    }
}
