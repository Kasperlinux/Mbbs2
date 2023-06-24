using Microsoft.AspNetCore.Mvc;

namespace Mbbs2.Controllers
{
    public class HeadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
