using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class ShipmentMovement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovementId { get; set; }

        // Hangi kargonun hareketi? (Shipment tablosuyla bağlantı)
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShipmentId { get; set; }

        // O anki işlem durumu (Yolda, Dağıtımda vs.)
        public ShipmentStatus Status { get; set; }

        // İşlemin yapıldığı yer (Örn: Kayseri Transfer Merkezi, Melikgazi Şubesi)
        public string Location { get; set; }

        // Müşteriye gösterilecek açıklama
        // Örn: "Gönderiniz araca yüklenmiş olup, varış şubesine doğru yola çıkmıştır."
        public string Description { get; set; }

        // Barkodun okutulduğu tam tarih ve saat
        public DateTime ProcessDate { get; set; }

        // Bu işlemi hangi personel/admin yaptı? (Güvenlik ve takip için)
        public string ProcessedByAdminId { get; set; }
    }
}
