using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MySite.Controllers
{
    public class Addresses : Controller
    {
        PostgresContext context = new PostgresContext();
        [HttpGet]
        public IActionResult SaveAddress()
             => View("~/Views/Home/Index.cshtml");

        [HttpPost]
        public IActionResult SaveAddress(Address address)
        {
            try
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
            catch (Exception ex) {
                ViewBag.Title = "Ошибка при добавлении";
                ViewBag.Message = ex?.InnerException?.Message;
                return RedirectToAction("SaveAddress", "Addresses");
            }

            return RedirectToAction("SaveAddress", "Addresses", new { message = "Успешно" });
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Address newAddress,int id)
        {
            Address? address = context.Addresses.FirstOrDefault(u=>u.Id==id);
            if (address != null)
            {
                address = newAddress;
            }
            else return RedirectToAction("Index", "Addresses");
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", "Addresses", new { ex?.InnerException?.Message });
            }

            return RedirectToAction("Delete", "Addresses", new { message = "Успешно" });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var address = context.Addresses.FirstOrDefault(u => u.Id == id);
            if (address == null) return RedirectToAction("Index", "Addresses");
            try
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses");
            }

            return RedirectToAction("Index", "Addresses");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        
    }
}
