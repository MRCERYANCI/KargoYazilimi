using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
