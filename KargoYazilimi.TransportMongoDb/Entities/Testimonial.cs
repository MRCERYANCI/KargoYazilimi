using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string FullName { get; set; }      // Müşteri Adı (Ahmet Yılmaz)
        public string Title { get; set; }         // Ünvan (Lojistik Müdürü)
        public string Comment { get; set; }       // Yorum Metni
        public string ImageUrl { get; set; }      // Profil Fotoğrafı URL
        public int StarCount { get; set; }        // Yıldız Sayısı (1-5 arası)
        public double RatingScore { get; set; }   // Puan (Örn: 4.95)
        public bool IsActive { get; set; }        // Yayında mı?
        public int OrderNo { get; set; }          // Slider sırası
    }
}
