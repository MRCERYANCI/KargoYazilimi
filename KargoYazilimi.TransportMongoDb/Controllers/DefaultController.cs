using KargoYazilimi.TransportMongoDb.Dtos.CareerApplicationDtos;
using KargoYazilimi.TransportMongoDb.Services.CareerApplicationServices;
using KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices;
using KargoYazilimi.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly ICareerApplicationService _careerApplicationService;
        private readonly IShipmentService _shipmentService;
        private readonly IShipmentMovementService _movementService;

        public DefaultController(ICareerApplicationService careerApplicationService, IShipmentService shipmentService, IShipmentMovementService movementService)
        {
            _careerApplicationService = careerApplicationService;
            _shipmentService = shipmentService;
            _movementService = movementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/misyon-ve-vizyon")]
        public IActionResult MisyonVizyon()
        {
            return View();
        }

        [HttpGet("/cerez-politikasi")]
        public async Task<IActionResult> CerezPolitikasi()
        {
            return View();
        }

        [HttpGet("/kullanim-sartlari")]
        public async Task<IActionResult> KullanimSartlari()
        {
            return View();
        }

        [HttpGet("/cokkececijet-ile-kariyer")]
        public async Task<IActionResult> Kariyer()
        {
            return View();
        }

        [HttpGet("/hakkimizda")]
        public async Task<IActionResult> About()
        {
            return View();
        }

        // Form gönderildiğinde çalışan POST metodu
        [HttpPost("/cokkececijet-ile-kariyer")]
        public async Task<IActionResult> Kariyer(CreateCareerApplicationDto createCareerApplicationDto)
        {
            // PDF kontrolü (Opsiyonel ama iyi olur)
            if (createCareerApplicationDto.CVFile != null)
            {
                var extension = Path.GetExtension(createCareerApplicationDto.CVFile.FileName).ToLower();
                if (extension != ".pdf")
                {
                    ModelState.AddModelError("CVFile", "Lütfen sadece PDF dosyası yükleyin.");
                    return View(createCareerApplicationDto);
                }
            }

            if (ModelState.IsValid)
            {
                await _careerApplicationService.CreateCareerApplicationAsync(createCareerApplicationDto);

                // Başarılı uyarısı için (Partial veya Script ile yakalayabilirsin)
                TempData["SuccessMessage"] = "Başvurunuz İnsan Kaynaklarımıza Başarıyla İletilmiştir. Değerlendirilip Size Geri Dönüş Yapılacaktır";
                return RedirectToAction("Kariyer");
            }

            return View(createCareerApplicationDto);
        }

        [HttpGet("/dagitim-agimiz")]
        public IActionResult DagitimAgi()
        {
            return View();
        }

        [HttpGet("/e-ticaret-lojistikimiz")]
        public IActionResult EticaretLogistis()
        {
            return View();
        }

        [HttpGet("gizlilik-politikasi")]
        public IActionResult GizlilikPolitikasi()
        {
            return View();
        }

        [HttpGet("/yasal/tazmin-prosedoru")]
        public IActionResult Tazmin()
        {
            return View();
        }

        [HttpGet("/kurye/evden-teslim")]
        public IActionResult KuryeCagir()
        {
            return View();
        }

        [HttpGet("/sirketimiz/yöneticiler")]
        public IActionResult Yoneticiler()
        {
            return View();
        }

        [HttpGet("/gönderi-takip/{trackingNumber}")]
        public async Task<IActionResult> KargoTakip(string trackingNumber)
        {
            var shipment = await _shipmentService.GetShipmentByTrackingNumberAsync(trackingNumber);

            if (shipment == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var movements = await _movementService.GetMovementsByShipmentIdAsync(shipment.ShipmentId);

            shipment.Movements = movements;

            return View(shipment);
        }

        [HttpGet("/gönderi-ara")]
        public async Task<IActionResult> GonderiAra()
        {
            return View();
        }

        [HttpGet("cokkececi-jet-kargo-dagitim-sureci-geri-bildirim-formu")]
        public IActionResult GeriBildirim(string id)
        {
            return View();
        }
    }
}
