using Microsoft.AspNetCore.Mvc;

namespace MyTechnic_Case.Web.ViewComponents.Footer
{
    public class FooterList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
