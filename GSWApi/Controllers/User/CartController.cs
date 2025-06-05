using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.User
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
