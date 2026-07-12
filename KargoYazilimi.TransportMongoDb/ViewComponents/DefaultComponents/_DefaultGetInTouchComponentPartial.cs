using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Services.BrandServices;
using KargoYazilimi.TransportMongoDb.Services.GetInTouchSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultGetInTouchComponentPartial : ViewComponent
    {
        private readonly IGetInTouchSectionService _getInTouchSectionService;

        public _DefaultGetInTouchComponentPartial(IGetInTouchSectionService getInTouchSection)
        {
            _getInTouchSectionService = getInTouchSection;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _getInTouchSectionService.GetAllGetInTouchSectionAsync());
        }
    }
}
