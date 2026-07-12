using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices;
using KargoYazilimi.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Mvc;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    public class CourierController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly IShipmentMovementService _movementService;
        private readonly IMapper _mapper;

        public CourierController(IShipmentService shipmentService, IShipmentMovementService movementService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _movementService = movementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _shipmentService.GetAllShipmentAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsDelivered(string id)
        {
            // 1. İlgili kargoyu bul
            var shipment = _mapper.Map<UpdateShipmentDto>(await _shipmentService.GetShipmentByIdAsync(id));

            if (shipment != null)
            {
                shipment.CurrentStatus = ShipmentStatus.Delivered;
                await _shipmentService.UpdateShipmentAsync(shipment);

                var movement = new CreateShipmentMovementDto
                {
                    ShipmentId = id,
                    Status = ShipmentStatus.Delivered,
                    Location = $"{shipment.ReceiverDistrict} / {shipment.ReceiverCity}", 
                    Description = "Teslimat Başarılı - Kargonuz teslim edilmiştir.",
                };
                await _movementService.CreateMovementAsync(movement);

                TempData["SuccessMessage"] = "Kargo başarıyla teslim edildi!";
            }

            return RedirectToAction("Index");
        }
    }
}
