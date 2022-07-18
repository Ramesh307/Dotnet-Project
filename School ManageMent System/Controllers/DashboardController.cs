using Microsoft.AspNetCore.Mvc;

namespace SchoolManageMentSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
