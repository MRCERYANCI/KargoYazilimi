using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferId { get; set; }

        public string Title { get; set; } // Örn: Deniz Taşımacılığı

        public string ShortDescription { get; set; } // Kart üzerindeki kısa metin

        public string? FullDescription { get; set; } // Detay sayfasında görünecek uzun metin

        public string IconUrl { get; set; } // Görsel yolu (Örn: ~/templates/assets/imgs/page/homepage1/cargo-ship.png)

        public string? Slug { get; set; } // URL dostu isim (Örn: deniz-tasimaciligi)

        public int OrderNo { get; set; } // Sıralama

        public bool IsActive { get; set; } // Yayında mı?
    }
}
