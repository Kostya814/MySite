using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                return RedirectToAction("Index", "Addresses");
            }
            ViewBag.Title = "Успешное добавление";
            ViewBag.Message = "Успешно добавлено";
            return RedirectToAction("Index", "Addresses");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Analitica.cshtml",context.Addresses);
        }
        [HttpGet]
        public IActionResult Edit(Address address)
        {
            return View("~/Views/Home/EditAddress.cshtml",address);
        }
        [HttpPost]
        public IActionResult Edit(Address newAddress,int id)
        {
            if (ModelState.IsValid)
            {
                Address? address = context.Addresses.Find(newAddress.Id);
                if (address != null)
                {
                    address.PrefixLocality = newAddress.PrefixLocality;
                    address.NameLocality = newAddress.NameLocality;
                    address.PrefixStreet = newAddress.PrefixStreet;
                    address.NameStreet = newAddress.NameStreet;
                    address.NumberHouse = newAddress.NumberHouse;
                    address.NumberCase  = newAddress.NumberCase;
                    address.NumberApartments = newAddress.NumberApartments;
                    address.NumberRoom = newAddress.NumberRoom;
                    address.LeterHome = newAddress.LeterHome;
                    address.Description  = newAddress.Description;
                }
            }
            else 
            {
                Address? address = context.Addresses.FirstOrDefault(u => u.Id == id);
                if (address != null)
                {
                    return RedirectToAction("Edit", "Addresses", address);
                }
                else return RedirectToAction("Index", "Addresses");
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Ошибка при изменении";
                ViewBag.Message = ex?.InnerException?.Message;
                return RedirectToAction("Index", "Addresses");
            }
            ViewBag.Title = "Успешное изменение адреса";
            ViewBag.Message = "Успешно изменено";
            return RedirectToAction("Index", "Addresses");
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
                ViewBag.Title = "Ошибка удаления";
                ViewBag.Message = ex?.InnerException?.Message;
                return RedirectToAction("Index", "Addresses");
            }
            ViewBag.Title = "Успешное удаление";
            ViewBag.Message = "Успешно удалено";
            return RedirectToAction("Index", "Addresses");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        
    }
}
