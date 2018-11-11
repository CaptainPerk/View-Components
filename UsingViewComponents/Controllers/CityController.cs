using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            _cityRepository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() => new ViewViewComponentResult
        {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, _cityRepository.Cities)
        };
    }
}
