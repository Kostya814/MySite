using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace MySite.Controllers
{
    public class Addresses : Controller
    {
        UnitOfWork.UnitOfWork unit = new UnitOfWork.UnitOfWork();
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cities = unit.Cities.GetAll().ToList();
            if (ViewBag.Cities.Count != 0) return View();
            return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при добавления", MessageResult = "Добавьте города" });
        }

        [HttpPost]
        public IActionResult Create(Address Address, int CityId)
        {
            Address.City = unit.Cities.Get(CityId);
            if(Address.City == null)
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка при добавлении", MessageResult = "Ошибка выбора города" });
            try
            {
                unit.Addresses.Create(Address);
                unit.Save();
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
            return RedirectToAction("Index", "Home", new { TitleResult= TitleResult, MessageResult = MessageResult });
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            Address? address = unit.Addresses.Get(id);
            if (address != null)
            {
                ViewBag.Cities = unit.Cities.GetAll().ToList();
                if(ViewBag.Cities.Count != 0) return View(address);
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактиирования", MessageResult = "Не найден список городов" });
            }
            else return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });

            
        }
        [HttpPost]
        public IActionResult Edit(Address newAddress,int CityId)
        {
            newAddress.City = unit.Cities.Get(CityId);
            if (newAddress.City !=null)
            {
                try
                {
                    unit.Addresses.Edit(newAddress);
                    unit.Save();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактирования", MessageResult = ex?.InnerException?.Message });
                }
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Успешное изменение адреса", MessageResult = "Успешно изменено" });
            }
            else
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка редактирования", MessageResult = "Не правильно введены данные" });
            }
           
        }
        [HttpPost]
        public IActionResult Delete(Address IdAddress)
        {
            Address? address = unit.Addresses.Get(IdAddress.Id);
            if (address == null) 
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден адрес" });
            try
            {
                unit.Addresses.Delete(address.Id);
                unit.Save();
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
            unit.Cities.GetAll();
            var address = unit.Addresses.Get(id);
            if (address == null)
            {
                return RedirectToAction("Index", "Addresses", new { TitleResult = "Ошибка поиска", MessageResult = "Не найден адрес" });
            }
            return View(address);
        }
        
    }
}
