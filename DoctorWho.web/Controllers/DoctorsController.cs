using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
