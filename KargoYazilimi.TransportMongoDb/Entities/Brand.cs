using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandId { get; set; }
        public string BrandName { get; set; } // Marka Adı (Yönetim için)

        public string ImageUrl { get; set; } // Marka Logo URL'si

        public string? WebsiteUrl { get; set; } // Opsiyonel: Markanın sitesine link

        public int OrderNo { get; set; } // Logoların yan yana dizilme sırası

        public bool IsActive { get; set; } // Yayında mı?
    }
}
