using KargoYazilimi.TransportMongoDb.Dtos.GetInTouchSectionDtos;
using KargoYazilimi.TransportMongoDb.Services.GetInTouchSectionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class GetInTouchSectionController : Controller
    {
        private readonly IGetInTouchSectionService _getInTouchSectionService;

        public GetInTouchSectionController(IGetInTouchSectionService brandService)
        {
            _getInTouchSectionService = brandService;
        }

        public async Task<IActionResult> GetInTouchSectionList()
        {
            var values = await _getInTouchSectionService.GetAllGetInTouchSectionAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGetInTouchSection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGetInTouchSection(CreateGetInTouchSectionDto createGetInTouchSectionDto)
        {
            await _getInTouchSectionService.CreateGetInTouchSectionAsync(createGetInTouchSectionDto);
            return RedirectToAction("GetInTouchSectionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGetInTouchSection(string id)
        {
            var value = await _getInTouchSectionService.GetInTouchSectionByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGetInTouchSection(UpdateGetInTouchSectionDto updateGetInTouchSectionDto)
        {
            await _getInTouchSectionService.UpdateGetInTouchSectionAsync(updateGetInTouchSectionDto);
            return RedirectToAction("GetInTouchSectionList");
        }

        public async Task<IActionResult> DeleteGetInTouchSection(string id)
        {
            await _getInTouchSectionService.DeleteGetInTouchSectionAsync(id);
            return RedirectToAction("GetInTouchSectionList");
        }
    }
}
