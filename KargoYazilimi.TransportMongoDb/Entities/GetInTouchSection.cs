using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class GetInTouchSection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GetInTouchSectionId { get; set; }
        public string Tag { get; set; } // Bize Ulaşın (Butonun üstündeki etiket)
        public string Title { get; set; } // Her Teslimatta Mükemmelliği Sunmaktan Gurur Duyuyoruz
        public string Description { get; set; } // Lojistik süreçlerinizde sürdürülebilir başarı... (Uzun Metin)
        public string SubTitle1 { get; set; } // Ticaretinizi Güçlendirin
        public string SubDescription1 { get; set; } // En güncel lojistik trendlerini...
        public string SubTitle2 { get; set; } // Modern Teknolojik Altyapı
        public string SubDescription2 { get; set; } // Dijital takip ve raporlama...
        public string ButtonText { get; set; } // İletişime Geçin
        public string ButtonUrl { get; set; } // contact.html veya yönlendirilecek link
        public string BackgroundImageUrl { get; set; } // Sağ taraftaki box-image-touch için arka plan görseli
    }
}
