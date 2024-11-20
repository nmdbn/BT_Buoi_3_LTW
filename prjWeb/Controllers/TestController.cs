using Microsoft.AspNetCore.Mvc;

namespace prjWeb.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
