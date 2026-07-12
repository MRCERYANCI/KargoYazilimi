using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BranchId { get; set; }

        public string BranchName { get; set; }  // Örn: Kayseri Melikgazi Şubesi
        public string BranchCode { get; set; }  // Örn: KY-MLK-01
        public string BranchType { get; set; }  // Şube veya Aktarma Merkezi

        public string City { get; set; }        // Kayseri
        public string District { get; set; }    // Melikgazi
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string ManagerName { get; set; }

        // Harita koordinatları
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
