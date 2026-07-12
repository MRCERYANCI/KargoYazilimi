using KargoYazilimi.TransportMongoDb.Services.HowItWorkServices;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultHowItWorksComponentPartial : ViewComponent
    {
        private readonly IHowItWorkService _howItWorkService;

        public _DefaultHowItWorksComponentPartial(IHowItWorkService brandService)
        {
            _howItWorkService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _howItWorkService.GetAllHowItWorkAsync());
        }
    }
}
