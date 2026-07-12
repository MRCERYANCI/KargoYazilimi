using KargoYazilimi.TransportMongoDb.Dtos.HowItWorkDtos;
using KargoYazilimi.TransportMongoDb.Services.HowItWorkServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class HowItWorkController : Controller
    {
        private readonly IHowItWorkService _howItWorkService;

        public HowItWorkController(IHowItWorkService brandService)
        {
            _howItWorkService = brandService;
        }

        public async Task<IActionResult> HowItWorkList()
        {
            var values = await _howItWorkService.GetAllHowItWorkAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateHowItWork()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHowItWork(CreateHowItWorkDto createHowItWorkDto)
        {
            await _howItWorkService.CreateHowItWorkAsync(createHowItWorkDto);
            return RedirectToAction("HowItWorkList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHowItWork(string id)
        {
            var value = await _howItWorkService.GetHowItWorkByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHowItWork(UpdateHowItWorkDto updateHowItWorkDto)
        {
            await _howItWorkService.UpdateHowItWorkAsync(updateHowItWorkDto);
            return RedirectToAction("HowItWorkList");
        }

        public async Task<IActionResult> DeleteHowItWork(string id)
        {
            await _howItWorkService.DeleteHowItWorkAsync(id);
            return RedirectToAction("HowItWorkList");
        }
    }
}
