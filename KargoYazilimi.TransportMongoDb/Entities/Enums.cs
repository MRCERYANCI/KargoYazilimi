namespace KargoYazilimi.TransportMongoDb.Entities
{
    public class Enums
    {
        public enum ShipmentStatus
        {
            Created = 1,        // Kargo Oluşturuldu (Şubede kabul edildi)
            InTransit = 2,      // Transfer Merkezinde / Yolda
            OutForDelivery = 3, // Dağıtıma Çıktı (Kuryede)
            Delivered = 4,      // Teslim Edildi
            FailedAttempt = 5,  // Teslim Edilemedi (Evde yok vs.)
            Canceled = 6,       // İptal Edildi
            Returned = 7,      // İade Edildi
            ArrivedAtBranch = 8
        }

        // Ödemeyi kim yapacak?
        public enum PaymentType
        {
            SenderPays = 1,     // Gönderici Ödemeli (Peşin)
            ReceiverPays = 2,   // Alıcı Ödemeli (Karşı Ödemeli)
            PlatformPays = 3    // Kurumsal/E-ticaret Anlaşmalı
        }

        // Kapıda ödeme durumu vs.
        public enum PaymentStatus
        {
            Pending = 1,        // Ödeme Bekliyor
            Paid = 2,           // Ödendi
            Refunded = 3        // İade Edildi
        }
    }
}
