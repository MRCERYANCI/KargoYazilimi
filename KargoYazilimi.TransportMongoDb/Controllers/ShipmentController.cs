using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices;
using KargoYazilimi.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
 
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService; // İsim düzeltildi
        private readonly IShipmentMovementService _movementService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentService shipmentService, IMapper mapper, IShipmentMovementService movementService)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
            _movementService = movementService;
        }

        [Route("Index")]
        [Route("ShipmentList")]
        public async Task<IActionResult> ShipmentList()
        {
            var values = await _shipmentService.GetAllShipmentAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateShipment")]
        public IActionResult CreateShipment() // View açılırken async'e gerek yok
        {
            return View();
        }

        [HttpPost]
        [Route("CreateShipment")]
        public async Task<IActionResult> CreateShipment(CreateShipmentDto createShipmentDto)
        {
            if (ModelState.IsValid)
            {
                await _shipmentService.CreateShipmentAsync(createShipmentDto);
                return RedirectToAction("ShipmentList");
            }
            return View(createShipmentDto); // Hata varsa aynı sayfaya form verileriyle dön
        }

        [HttpGet]
        [Route("UpdateShipment/{id}")]
        public async Task<IActionResult> UpdateShipment(string id)
        {
            // Veritabanından GetShipmentByIdDto olarak geliyor
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);

            // View sayfasının beklediği UpdateShipmentDto modeline dönüştürüyoruz
            var updateModel = _mapper.Map<UpdateShipmentDto>(shipment);

            return View(updateModel);
        }

        [HttpPost]
        [Route("UpdateShipment/{id}")]
        public async Task<IActionResult> UpdateShipment(UpdateShipmentDto updateShipmentDto)
        {
            await _shipmentService.UpdateShipmentAsync(updateShipmentDto);
            return RedirectToAction("ShipmentList");
        }

        [Route("DeleteShipment/{id}")]
        public async Task<IActionResult> DeleteShipment(string id)
        {
            await _shipmentService.DeleteShipmentAsync(id);
            return RedirectToAction("ShipmentList");
        }

        // --- EKSTRA: KARGO DETAY SAYFASI ---
        [HttpGet]
        [Route("ShipmentDetail/{id}")]
        public async Task<IActionResult> ShipmentDetail(string id)
        {
            // Kargonun A'dan Z'ye tüm bilgilerini (hareketleri dahil) getireceğimiz sayfa
            var value = await _shipmentService.GetShipmentByIdAsync(id);
            return View(value);
        }

        [HttpGet]
        [Route("PrintBarcode/{id}")]
        public async Task<IActionResult> PrintBarcode(string id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            return View(shipment);
        }

        [HttpGet]
        [Route("AddMovement/{id}")]
        public IActionResult AddMovement(string id)
        {
            // Hangi kargoya hareket eklediğimizi formda tutmak için ID'yi View'a gönderiyoruz
            var model = new CreateShipmentMovementDto { ShipmentId = id };
            return View(model);
        }

        [HttpPost]
        [Route("AddMovement/{id}")]
        public async Task<IActionResult> AddMovement(CreateShipmentMovementDto createShipmentMovementDto)
        {
            // 1. Yeni hareketi log (timeline) tablosuna ekle
            await _movementService.CreateMovementAsync(createShipmentMovementDto);

            // 2. Kargonun ana statüsünü de bu yeni harekete göre güncelle
            var shipment = await _shipmentService.GetShipmentByIdAsync(createShipmentMovementDto.ShipmentId);
            if (shipment != null)
            {
                var updateDto = _mapper.Map<UpdateShipmentDto>(shipment);
                updateDto.CurrentStatus = createShipmentMovementDto.Status;

                // Eğer kargo "Teslim Edildi" seçildiyse, servisimiz zaten teslimat tarihini atacaktır.
                await _shipmentService.UpdateShipmentAsync(updateDto);
            }

            // İşlem bitince kargonun listesine (veya detayına) geri dön
            return RedirectToAction("ShipmentList");
        }

        [HttpGet]
        [Route("GetCourierLocation/{deviceId}")]
        public async Task<IActionResult> GetCourierLocation(int deviceId)
        {
            string token = "";

            // Çerezleri (Cookie) hafızada tutması için bir Handler oluşturuyoruz
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                try
                {
                    // 1. ADIM: Token ile Traccar'da Session (Oturum) Açıyoruz
                    string sessionUrl = $"";
                    var sessionResponse = await client.GetAsync(sessionUrl);

                    if (sessionResponse.IsSuccessStatusCode)
                    {
                        // 2. ADIM: Oturum başarıyla açıldı! Şimdi konumları çekiyoruz
                        string positionsUrl = "";
                        var positionsResponse = await client.GetAsync(positionsUrl);

                        if (positionsResponse.IsSuccessStatusCode)
                        {
                            var content = await positionsResponse.Content.ReadAsStringAsync();
                            return Content(content, "application/json"); // Veriyi başarıyla haritaya gönder
                        }
                    }

                    return BadRequest("Traccar oturumu açılamadı veya yetki reddedildi.");
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest("Konum alınamadı.");
        }
    }
}
