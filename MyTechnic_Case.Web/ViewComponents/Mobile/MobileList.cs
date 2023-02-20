using Microsoft.AspNetCore.Mvc;

namespace MyTechnic_Case.Web.ViewComponents.Mobile
{
    public class MobileList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
