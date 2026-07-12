using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class CareerApplication
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CareerApplicationId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; } // IT, Driver, Warehouse vb.
        public string LicenseClass { get; set; } // Ehliyet Sınıfı
        public string ExperienceYear { get; set; } // 0-1, 1-3 vb.
        public string MilitaryStatus { get; set; } // Done, Exempt, Postponed
        public string CVPath { get; set; } // Sunucuya kaydedilen PDF'in yolu
        public string CoverLetter { get; set; } // Ön yazı
        public DateTime AppliedAt { get; set; } // Başvuru tarihi (Otomatik atanmalı)
        public bool IsReviewed { get; set; } // İK tarafından incelendi mi?
        public string Status { get; set; } // Pending, Approved, Rejected
    }
}
