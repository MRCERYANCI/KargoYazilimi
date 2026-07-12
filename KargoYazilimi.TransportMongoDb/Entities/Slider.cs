using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderId { get; set; }
        public string? SmallTitle { get; set; } // Hızın Güvenceyle Buluştuğu Nokta

        public string? MainTitle { get; set; }  // Dijital ve Güvenilir Ulaşım ÇokkeçeciJet

        public string? Description { get; set; } // Deneyimli problem çözücü ekibimiz...

        public string? ImageUrl { get; set; }   // banner.png yolu

        public string? Button1Text { get; set; } // Paket Hesapla

        public string? Button1Url { get; set; }

        public string? VideoUrl { get; set; }   // YouTube Linki

        public int OrderNo { get; set; }        // Sıralama

        public bool IsActive { get; set; }      // Aktif/Pasif
    }
}
