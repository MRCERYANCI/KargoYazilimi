using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultCalculatorShippingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
