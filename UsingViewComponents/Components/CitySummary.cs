using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private readonly ICityRepository _cityRepository;

        public CitySummary(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IViewComponentResult Invoke()
        {
            string target = RouteData.Values["id"] as string;
            var cities = _cityRepository.Cities.Where(c => target == null || string.Compare(c.Country, target, true) == 0);
            return View(new CityViewModel {Cities = cities.Count(), Population = cities.Sum(c => c.Population)});
        }
    }
}
