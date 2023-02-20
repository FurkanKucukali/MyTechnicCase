using Microsoft.AspNetCore.Mvc;

namespace MyTechnic_Case.Web.ViewComponents.Header
{
    public class HeaderList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
