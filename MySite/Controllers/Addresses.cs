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
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при добавлении", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное добавление", MessageResult = "Успешно добавлено" });
        }
        [HttpGet]
        public IActionResult Index(string TitleResult, string MessageResult)
        {
            if(ModelState.IsValid)
            {
                ViewBag.TitleResult = TitleResult;
                ViewBag.MessageResult = MessageResult;
            }            
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
                Address? address = context.Addresses.Find(id);
                if (address != null)
                {
                    return RedirectToAction("Edit", "Addresses", address);
                }
                else return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при изменении", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное изменение адреса", MessageResult = "Успешно изменено" });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var address = context.Addresses.Find(id);
            if (address == null)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" }); 
            }
            try
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses",new { TitleResult = "Ошибка удаления", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное удаление", MessageResult = "Успешно удалено" });
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        
    }
}
