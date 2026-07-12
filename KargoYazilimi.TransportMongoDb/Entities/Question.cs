using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId { get; set; }
        public string QuestionTitle { get; set; } // Gönderimi nasıl takip edebilirim?
        public string Answer { get; set; }   // Size iletilen takip numarası ile...
        public int OrderNo { get; set; }     // Soruların hangi sırayla dizileceği
        public bool IsActive { get; set; }   // Soru yayında mı?
    }
}
