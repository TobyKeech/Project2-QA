using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
