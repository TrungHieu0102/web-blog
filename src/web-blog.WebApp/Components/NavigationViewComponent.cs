using Microsoft.AspNetCore.Mvc;

namespace web_blog.WebApp.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}