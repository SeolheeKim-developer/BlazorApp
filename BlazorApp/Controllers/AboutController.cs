using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
