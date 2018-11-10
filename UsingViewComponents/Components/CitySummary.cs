using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
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

        public IViewComponentResult Invoke() => new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
    }
}
