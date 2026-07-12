using KargoYazilimi.TransportMongoDb.Dtos.BranchDtos;
using KargoYazilimi.TransportMongoDb.Services.BranchService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService brandService)
        {
            _branchService = brandService;
        }

        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllBranchAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            await _branchService.CreateBranchAsync(createBranchDto);
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBranch(string id)
        {
            var value = await _branchService.GetByIdBranchAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            await _branchService.UpdateBranchAsync(updateBranchDto);
            return RedirectToAction("BranchList");
        }

        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteBranchAsync(id);
            return RedirectToAction("BranchList");
        }

        [AllowAnonymous]
        [HttpGet("subelerimiz")]
        public async Task<IActionResult> BranchUIList()
        {
            var values = await _branchService.GetAllBranchAsync();
            return View(values);
        }
    }
}
