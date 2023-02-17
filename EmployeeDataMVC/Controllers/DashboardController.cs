using Microsoft.AspNetCore.Mvc;

namespace EmployeeDataMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
