using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace MySite.Controllers
{
    public class Addresses : Controller
    {
        PostgresContext context = new PostgresContext();

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cities = context.Cities.ToList();
            if (ViewBag.Cities.Count != 0) return View();
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при добавления", MessageResult = "Добавьте города" });
        }

        [HttpPost]
        public IActionResult Create(Address Address, int CityId)
        {
            Address.City = context.Cities.Find(CityId);
            if(Address.City == null)
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при добавлении", MessageResult = "Ошибка выбора города" });
            try
            {
                context.Addresses.Add(Address);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
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
            return RedirectToAction("Index", "Addresses", new { TitleResult= TitleResult, MessageResult = MessageResult });
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            Address? address = context.Addresses.Find(id);
            if (address != null)
            {
                ViewBag.Cities = context.Cities.ToList();
                if(ViewBag.Cities.Count != 0) return View(address);
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактиирования", MessageResult = "Не найден список городов" });
            }
            else return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });

            
        }
        [HttpPost]
        public IActionResult Edit(Address newAddress,int CityId)
        {
            newAddress.City = context.Cities.Find(CityId);
            if (newAddress.City !=null)
            {
                Address? address = context.Addresses.Find(newAddress.Id);
                if (address != null)
                {
                    address.City = newAddress.City;
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
        public IActionResult Delete(Address IdAddress)
        {
            Address? address = context.Addresses.Find(IdAddress.Id);
            if (address == null) 
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден адрес" });
            try
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка удаления", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное удаление", MessageResult = "Успешно удалено" });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            context.Cities.ToList();
            var address = context.Addresses.Find(id);
            if (address == null)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });
            }
            return View(address);
        }
        
    }
}
