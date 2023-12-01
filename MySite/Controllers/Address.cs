using Microsoft.AspNetCore.Mvc;

namespace MySite.Controllers
{
    public class Address : Controller
    {
        public IActionResult SaveAddress()
        {
            return View();
        }
    }
}
