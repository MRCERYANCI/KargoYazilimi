using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos
{
    public class ResultShipmentDto
    {
        public string ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public ShipmentStatus CurrentStatus { get; set; }

        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCity { get; set; }
        public string SenderDistrict { get; set; }
        public string ReceiverNeighborhood { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverDistrict { get; set; }
        public string ReceiverAddress { get; set; } // Dağıtım için lazım

        public string OriginBranchId { get; set; }
        public string DestinationBranchId { get; set; }

        public int PackageCount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalDesi { get; set; }

        public bool HasCashOnDelivery { get; set; }
        public decimal CashOnDeliveryAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public double ReceiverLatitude { get; set; } // Müşterinin Evinin Enlemi (Örn: 38.7205)
        public double ReceiverLongitude { get; set; } // Müşterinin Evinin Boylamı (Örn: 35.4826)
    }
}
