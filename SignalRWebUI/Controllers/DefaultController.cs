using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage()
        {
            return RedirectToAction("Index");
        }
    }
}
