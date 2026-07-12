using KargoYazilimi.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultWhatWeHaveDoneComponentPartial : ViewComponent
    {
        private readonly IProjectSectionService _projectSectionService;

        public _DefaultWhatWeHaveDoneComponentPartial(IProjectSectionService brandService)
        {
            _projectSectionService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _projectSectionService.GetAllProjectSectionAsync());
        }
    }
}
