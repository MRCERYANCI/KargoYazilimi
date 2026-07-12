using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
