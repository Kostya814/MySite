using Microsoft.AspNetCore.Mvc;
using MySite;
using System.Net;

namespace MySite.Controllers
{
    public class City : Controller
    {
        PostgresContext context = new PostgresContext();
        public IActionResult Index(string TitleResult, string MessageResult)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TitleResult = TitleResult;
                ViewBag.MessageResult = MessageResult;
            }
            return RedirectToAction("Index", "City", new { TitleResult = TitleResult, MessageResult = MessageResult });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MySite.City city)
        {
            try
            {
                context.Add(city);
                context.SaveChanges();
            }
            catch(Exception ex) 
            {
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка при добавлении", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "City", new { TitleResult = "Успешное добавление", MessageResult = "Успешно добавлено" });
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            MySite.City? city = context.Cities.Find(id);
            if(city == null)
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка изменеия", MessageResult = "Не найден город" });
            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(MySite.City newCity) 
        {
            if (ModelState.IsValid)
            {
                MySite.City? city = context.Cities.Find(newCity.Id);
                if (city == null)
                    return RedirectToAction("Index", "City", new { TitleResult = "Ошибка изменеия", MessageResult = "Не найден город" });
                else
                { 
                    city.PrefixLocality = newCity.PrefixLocality;
                    city.NameLocality = newCity.NameLocality;
                }
                try
                {
                    context.SaveChanges();
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
            MySite.City? city = context.Cities.Find(id);
            if(city == null) 
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден город" });
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(MySite.City city)
        {
            MySite.City? City = context.Cities.Find(city.Id);
            if(City == null) return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = "Не найден город" });
            try
            {
                if(City.Addresses!=null) context.RemoveRange(City.Addresses);
                context.Cities.Remove(City);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "City", new { TitleResult = "Ошибка удаления", MessageResult = ex?.InnerException?.Message });
            }
            return RedirectToAction("Index", "City", new { TitleResult = "Успешное удаление", MessageResult = "Успешно удалено" });
        }
    }
}
