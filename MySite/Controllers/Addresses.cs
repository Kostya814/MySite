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
        public IActionResult Edit(int id)
        {
            Address? address = context.Addresses.Find(id);
            if (address != null)
            {
                return View("~/Views/Home/EditAddress.cshtml", address);
            }
            else return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });

            
        }
        [HttpPost]
        public IActionResult Edit(Address newAddress)
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
                    address.NumberCase = newAddress.NumberCase;
                    address.NumberApartments = newAddress.NumberApartments;
                    address.NumberRoom = newAddress.NumberRoom;
                    address.LeterHome = newAddress.LeterHome;
                    address.Description = newAddress.Description;
                }
                else return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактирования", MessageResult = "Изменяемый элемент не найден" });
            }
            else
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактирования", MessageResult = "Не правильно введены данные" });
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактирования", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное изменение адреса", MessageResult = "Успешно изменено" });
        }
        [HttpPost]
        public IActionResult Delete(Address address)
        {
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
        public IActionResult Delete(int id)
        {
            var address = context.Addresses.Find(id);
            if (address == null)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });
            }
            return RedirectToAction("Delete", "Addresses",address );
        }
        
    }
}
