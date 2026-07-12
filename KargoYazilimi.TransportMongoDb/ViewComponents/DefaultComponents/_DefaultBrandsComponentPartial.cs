using KargoYazilimi.TransportMongoDb.Services.BrandServices;
using KargoYazilimi.TransportMongoDb.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBrandsComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _DefaultBrandsComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _brandService.GetAllBrandAsync());
        }
    }
}
