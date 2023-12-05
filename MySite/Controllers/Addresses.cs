using Microsoft.AspNetCore.Mvc;

namespace MySite.Controllers
{
    public class Addresses : Controller
    {
        [HttpGet]
        public IActionResult SaveAddress(string message) 
             => Content($"{message}");

        [HttpPost]
        public IActionResult SaveAddress(Address address)
        {
            
            PostgresContext context = new PostgresContext();
            try 
            { 
                context.Addresses.Add(address);
                context.SaveChanges();
            }
            catch(Exception ex) { 
                return RedirectToAction("SaveAddress", "Addresses", new{ ex?.InnerException?.Message});
            }

            return RedirectToAction("SaveAddress", "Addresses", new{ message = "Успешно" });
        }
    }
}
