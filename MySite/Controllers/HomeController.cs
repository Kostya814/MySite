using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System.Diagnostics;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        PostgresContext _postgresContext = new PostgresContext();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }
        [HttpGet]
        public IActionResult Index(string TitleResult, string MessageResult)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TitleResult = TitleResult;
                ViewBag.MessageResult = MessageResult;
            }
            _postgresContext.Cities.ToList();
            return View(_postgresContext);
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
