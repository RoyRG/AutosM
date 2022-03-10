using Microsoft.AspNetCore.Mvc;

namespace Api.WebAuto.Controllers
{
    public class AutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
