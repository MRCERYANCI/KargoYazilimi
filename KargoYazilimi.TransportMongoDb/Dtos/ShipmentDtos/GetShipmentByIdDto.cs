using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos
{
    public class GetShipmentByIdDto
    {
        public string ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public ShipmentStatus CurrentStatus { get; set; }

        // --- GÖNDERİCİ ---
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCity { get; set; }
        public string SenderDistrict { get; set; }
        public string SenderNeighborhood { get; set; }
        public string SenderAddress { get; set; }

        // --- ALICI ---
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverDistrict { get; set; }
        public string ReceiverNeighborhood { get; set; }
        public string ReceiverAddress { get; set; }

        // --- ŞUBE BİLGİLERİ ---
        public string OriginBranchId { get; set; }
        public string DestinationBranchId { get; set; }

        // --- KARGO DETAYLARI ---
        public int PackageCount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalDesi { get; set; }
        public string PackageType { get; set; }
        public string ContentDescription { get; set; }
        public bool IsFragile { get; set; }

        // --- FİNANS & ÖDEME ---
        public bool HasCashOnDelivery { get; set; }
        public decimal CashOnDeliveryAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        // --- TARİHLER & NOTLAR ---
        public DateTime CreatedDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string DeliveryNotes { get; set; }
        public string OriginBranchName { get; set; } // Çıkış Şubesi Adı
        public string DestinationBranchName { get; set; } // Varış Şubesi Adı
        public int CourierDeviceId { get; set; } // Traccar'daki aracın ID'si (Örn: 1, 2, 5)
        public double ReceiverLatitude { get; set; } // Müşterinin Evinin Enlemi (Örn: 38.7205)
        public double ReceiverLongitude { get; set; } // Müşterinin Evinin Boylamı (Örn: 35.4826)

        // --- KRİTİK NOKTA: KARGO HAREKETLERİ ---
        // Bu kargoyu Id'ye göre çekerken, içindeki tüm lokasyon ve durum geçmişini 
        // liste olarak bu DTO'nun içine dolduracağız. (Müşteri Takip Ekranı için şart!)
        public List<ResultShipmentMovementDto> Movements { get; set; }
    }
}
