using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    public class EpisodesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
