using Microsoft.AspNetCore.Mvc;

namespace WebFamilyKey2.Controllers
{
    public class WebFamilyApi : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
