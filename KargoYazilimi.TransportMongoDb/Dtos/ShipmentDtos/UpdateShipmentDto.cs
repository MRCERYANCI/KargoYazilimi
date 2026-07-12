using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos
{
    public class UpdateShipmentDto
    {
        public string ShipmentId { get; set; }

        // Sadece güncellenebilecek mantıklı alanları ekliyoruz
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverDistrict { get; set; }
        public string ReceiverNeighborhood { get; set; }
        public string ReceiverAddress { get; set; }

        public string DestinationBranchId { get; set; }
        public ShipmentStatus CurrentStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public string DeliveryNotes { get; set; }
    }
}
