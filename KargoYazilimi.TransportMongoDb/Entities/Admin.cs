using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AdminId { get; set; }

        // Kimlik Bilgileri
        public string Name { get; set; } // Ad
        public string Surname { get; set; } // Soyad
        public string Email { get; set; } // Giriş için kullanılabilir
        public string Username { get; set; } // Kullanıcı adı
        public string PasswordHash { get; set; } // Şifre (Asla açık metin tutma, Hash'le!)

        // Profil Detayları
        public string ImageUrl { get; set; } // Admin profil resmi
        public string PhoneNumber { get; set; }

        // Güvenlik ve Durum
        public string Role { get; set; } // Admin, Moderator, Manager vb.
        public bool IsActive { get; set; } // Hesap aktif mi?
        public bool IsLocked { get; set; } // Çok hatalı girişten hesap kilitlendi mi?

        // İzleme (Tracking)
        public DateTime CreatedDate { get; set; } // Hesap ne zaman açıldı?
        public DateTime? LastLoginDate { get; set; } // En son ne zaman girdi?
        public string LastLoginIp { get; set; } // En son hangi IP'den girdi? (Güvenlik için önemli)
    }
}

