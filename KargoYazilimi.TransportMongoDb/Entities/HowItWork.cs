using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class HowItWork
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HowItWorkId { get; set; }
        public string Title { get; set; }       // Müşteri Siparişi Oluşturur
        public string Description { get; set; } // Ürünlerin incelenmesi ve kalite...
        public string IconUrl { get; set; }     // ~/templates/assets/imgs/.../order.png
        public int OrderNo { get; set; }        // 1, 2, 3, 4, 5 (Sıralama için)
    }
}
