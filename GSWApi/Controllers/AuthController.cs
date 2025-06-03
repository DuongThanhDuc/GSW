using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
