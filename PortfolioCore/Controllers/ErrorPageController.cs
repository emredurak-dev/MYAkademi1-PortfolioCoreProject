using Microsoft.AspNetCore.Mvc;

namespace PortfolioCore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
