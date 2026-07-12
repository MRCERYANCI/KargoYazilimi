using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos
{
    public class ResultShipmentMovementDto
    {
        public string MovementId { get; set; }
        public string ShipmentId { get; set; }
        public ShipmentStatus Status { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProcessedByAdminId { get; set; }
    }
}
