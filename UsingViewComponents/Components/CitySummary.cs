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

        public IViewComponentResult Invoke(bool showList) => showList ? 
            View("CityList", _cityRepository.Cities) : 
            View(new CityViewModel {Cities = _cityRepository.Cities.Count(), Population = _cityRepository.Cities.Sum(c => c.Population)});        
    }
}
