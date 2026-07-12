using KargoYazilimi.TransportMongoDb.Services.CareerApplicationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class CareerController : Controller
    {
        private readonly ICareerApplicationService _careerApplicationService;

        public CareerController(ICareerApplicationService careerApplicationService)
        {
            _careerApplicationService = careerApplicationService;
        }

        public async Task<IActionResult> CareerList()
        {
            var values = await _careerApplicationService.GetAllCareerApplicationAsync();
            return View(values);
        }
    }
}
