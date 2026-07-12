using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos
{
    public class CreateShipmentMovementDto
    {
        public string ShipmentId { get; set; }
        public ShipmentStatus Status { get; set; }
        public string Location { get; set; } // Örn: Kayseri Transfer Merkezi
        public string Description { get; set; } // Örn: Kargo yola çıktı

        // İşlemi yapan personeli arka planda Controller'dan (User.Identity'den) alıp buraya basacağız.
        public string ProcessedByAdminId { get; set; }
    }
}
