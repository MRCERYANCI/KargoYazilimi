using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string Title { get; set; } // En modern teknolojiyle hızlı sevkiyat
        public string Description { get; set; } // Yıllar içinde... ile başlayan uzun yazı
        public string ImageUrl { get; set; } // Sol taraftaki ana görsel
        public string IconUrl { get; set; } // Görselin yanındaki küçük ikon
        public List<string> Features { get; set; } // Tick (check) listesindeki özellikler
        public bool IsActive { get; set; }
    }
}
