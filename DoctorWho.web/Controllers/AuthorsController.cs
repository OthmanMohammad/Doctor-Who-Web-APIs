using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
