using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsingViewComponents.Components
{
    public class PageSize : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("http://apress.com");
            return View(httpResponseMessage.Content.Headers.ContentLength);
        }
    }
}
