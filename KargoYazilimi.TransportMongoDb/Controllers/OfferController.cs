using KargoYazilimi.TransportMongoDb.Dtos.OfferDtos;
using KargoYazilimi.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService _sliderService;

        public OfferController(IOfferService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> OfferList()
        {
            var values = await _sliderService.GetAllOfferAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            await _sliderService.CreateOfferAsync(createOfferDto);
            return RedirectToAction("OfferList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOffer(string id)
        {
            var value = await _sliderService.GetSldierByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            await _sliderService.UpdateOfferAsync(updateOfferDto);
            return RedirectToAction("OfferList");
        }

        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _sliderService.DeleteOfferAsync(id);
            return RedirectToAction("OfferList");
        }

        [AllowAnonymous]
        [Route("hizmet-detay/{slug}")]
        public async Task<IActionResult> OfferDetail(string slug)
        {
            // Service tarafında GetOfferBySlugAsync metodu olduğunu varsayıyorum
            var value = await _sliderService.GetOfferBySlugAsync(slug);
            if (value == null) return NotFound();

            return View(value);
        }
    }
}
