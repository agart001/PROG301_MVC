using Microsoft.AspNetCore.Mvc;

namespace PROG301_MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
