using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
