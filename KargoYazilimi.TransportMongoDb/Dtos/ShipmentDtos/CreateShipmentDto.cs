using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos
{
    public class CreateShipmentDto
    {
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCity { get; set; }
        public string SenderDistrict { get; set; }
        public string SenderNeighborhood { get; set; }
        public string SenderAddress { get; set; }

        // Alıcı
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverDistrict { get; set; }
        public string ReceiverNeighborhood { get; set; }
        public string ReceiverAddress { get; set; }

        // Şube
        public string OriginBranchId { get; set; }
        public string DestinationBranchId { get; set; }

        // Paket
        public int PackageCount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalDesi { get; set; }
        public string PackageType { get; set; } // Zarf, Koli vs.
        public string ContentDescription { get; set; }

        // Ekstra & Finans
        public bool IsFragile { get; set; }
        public bool HasCashOnDelivery { get; set; }
        public decimal CashOnDeliveryAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public PaymentType PaymentType { get; set; }

        public string DeliveryNotes { get; set; }
    }
}
