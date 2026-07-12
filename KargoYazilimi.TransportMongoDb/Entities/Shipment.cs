using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Shipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShipmentId { get; set; }

        public string TrackingNumber { get; set; }
        public ShipmentStatus CurrentStatus { get; set; }

        // --- GÖNDERİCİ (SENDER) BİLGİLERİ ---
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCity { get; set; }         // İL
        public string SenderDistrict { get; set; }     // İLÇE (İstediğin gibi burada)
        public string SenderNeighborhood { get; set; } // MAHALLE (Kurye için kritik)
        public string SenderAddress { get; set; }      // TAM ADRES (Sokak, No, Daire)

        // --- ALICI (RECEIVER) BİLGİLERİ ---
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCity { get; set; }         // İL
        public string ReceiverDistrict { get; set; }     // İLÇE 
        public string ReceiverNeighborhood { get; set; } // MAHALLE 
        public string ReceiverAddress { get; set; }      // TAM ADRES (Sokak, No, Daire)

        // --- ŞUBE VE ROTA BİLGİLERİ ---
        public string OriginBranchId { get; set; }
        public string DestinationBranchId { get; set; }

        // --- PAKET DETAYLARI ---
        public int PackageCount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalDesi { get; set; }
        public string PackageType { get; set; }
        public string ContentDescription { get; set; }

        // --- EKSTRA HİZMETLER ---
        public bool IsFragile { get; set; }
        public bool HasCashOnDelivery { get; set; }
        public decimal CashOnDeliveryAmount { get; set; }

        // --- FİNANSAL BİLGİLER ---
        public decimal ShippingFee { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        // --- TARİHLER VE NOTLAR ---
        public DateTime CreatedDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string DeliveryNotes { get; set; }
    }
}
