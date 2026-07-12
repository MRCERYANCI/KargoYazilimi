using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBoxBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
