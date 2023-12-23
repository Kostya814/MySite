using Microsoft.AspNetCore.Mvc;
using MySite;
using System.Net;

namespace MySite.Controllers
{
    public class City : Controller
    {
        UnitOfWork.UnitOfWork unit = new UnitOfWork.UnitOfWork();
        public IActionResult Index(string TitleResult, string MessageResult)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TitleResult = TitleResult;
                ViewBag.MessageResult = MessageResult;
            }
            return RedirectToAction("Index", "Home", new { TitleResult = TitleResult, MessageResult = MessageResult });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MySite.City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unit.Cities.Create(city);
                    unit.Save();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "City", new { TitleResult = "Ошибка при добавлении", MessageResult = ex?.InnerException?.Message });
                }
                return RedirectToAction("Index", "City", new { TitleResult = "Успешное добавление", MessageResult = "Успешно добавлено" }); unit.Cities.Create(city);
            }
            return RedirectToAction("Index", "City", new { TitleResult = "Ошибка при добавлении", MessageResult = "" });
            
           
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            MySite.City? city = unit.Cities.Get(id);
            if(city == null)
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка изменеия", MessageResult = "Не найден город" });
            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(MySite.City newCity) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unit.Cities.Edit(newCity);
                    unit.Save();
                }
                catch (Exception ex) 
                {
                    return RedirectToAction("Index", "City", new { TitleResult = "Ошибка изменеия", MessageResult = ex?.InnerException?.Message });
                }
                return RedirectToAction("Index", "City", new { TitleResult = "Успешное изменение", MessageResult = "Успешное изменения города" });

            }
            return RedirectToAction("Index", "City", new { TitleResult = "Ошибка изменеия", MessageResult = "Не верно введены данные" });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            MySite.City? city = unit.Cities.Get(id);
            if(city == null) 
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден город" });
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(MySite.City city)
        {
            MySite.City? City = unit.Cities.Get(city.Id);
            if(City == null) return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден город" });
            try
            {
                unit.Cities.Delete(City.Id);
                unit.Save();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "City", new { TitleResult = "Успешное удаление", MessageResult = "Успешно удалено" });
        }
    }
}
