using KargoYazilimi.TransportMongoDb.Dtos.ProjectSectionDtos;
using KargoYazilimi.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class ProjectSectionController : Controller
    {
        private readonly IProjectSectionService _projectSectionService;

        public ProjectSectionController(IProjectSectionService brandService)
        {
            _projectSectionService = brandService;
        }

        public async Task<IActionResult> ProjectSectionList()
        {
            var values = await _projectSectionService.GetAllProjectSectionAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProjectSection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectSection(CreateProjectSectionDto createProjectSectionDto)
        {
            await _projectSectionService.CreateProjectSectionAsync(createProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProjectSection(string id)
        {
            var value = await _projectSectionService.GetProjectSectionByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProjectSection(UpdateProjectSectionDto updateProjectSectionDto)
        {
            await _projectSectionService.UpdateProjectSectionAsync(updateProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }

        public async Task<IActionResult> DeleteProjectSection(string id)
        {
            await _projectSectionService.DeleteProjectSectionAsync(id);
            return RedirectToAction("ProjectSectionList");
        }

        [AllowAnonymous]
        [HttpGet("/proje/{slug}")]
        public async Task<IActionResult> GetProjectDetail(string slug)
        {
            return View(await _projectSectionService.GetProjectSectionBySlugAsync(slug));
        }
    }
}
