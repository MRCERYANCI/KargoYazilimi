using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class ProjectSection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectSectionId { get; set; }
        public string Title { get; set; }           // Hava Kargo Operasyonu
        public string ShortDescription { get; set; } // Slider'da görünen kısa özet
        public string FullDescription { get; set; }  // Detay sayfasındaki uzun metin
        public string ImageUrl { get; set; }        // Ana görsel
        public string Category { get; set; }         // Hava, Deniz, Kara vb.
        public string Slug { get; set; }             // hava-kargo-operasyonu (URL için)
        public string MetaTitle { get; set; }        // SEO Başlığı
        public string MetaDescription { get; set; }  // SEO Açıklaması
        public int OrderNo { get; set; }            // Sıralama
        public bool IsActive { get; set; }          // Yayında mı?
        public DateTime CreatedDate { get; set; }    // Eklenme Tarihi
    }
}
