using KargoYazilimi.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IOfferService _offerService;

        public _DefaultOfferComponentPartial(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _offerService.GetAllOfferAsync());
        }
    }
}
