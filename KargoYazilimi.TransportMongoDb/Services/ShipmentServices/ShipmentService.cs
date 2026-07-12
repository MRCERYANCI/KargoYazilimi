using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Services.ShipmentServices
{
    public class ShipmentService : IShipmentService
    {
        private readonly IMongoCollection<Shipment> _shipmentCollection;
        private readonly IMongoCollection<Branch> _branchCollection; // Şube adını bulmak için eklendi
        private readonly IShipmentMovementService _shipmentMovementService; // Hareket servisi eklendi
        private readonly IMapper _mapper;

        public ShipmentService(IMapper mapper, IDatabaseSettings _databaseSettings, IShipmentMovementService shipmentMovementService)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);

            _shipmentCollection = database.GetCollection<Shipment>(_databaseSettings.ShipmentCollectionName);
            _branchCollection = database.GetCollection<Branch>(_databaseSettings.BranchCollectionName); // Şube koleksiyonu bağlandı

            _shipmentMovementService = shipmentMovementService;
            _mapper = mapper;
        }

        public async Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
        {
            var shipment = _mapper.Map<Shipment>(createShipmentDto);

            // 1. Eşsiz Takip Numarası Üretimi
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            shipment.TrackingNumber = $"CJET-{datePart}-{randomPart}";

            // 2. İlk durum tanımlamaları
            shipment.CurrentStatus = ShipmentStatus.Created;
            shipment.CreatedDate = DateTime.Now;

            // 3. Kargoyu Veritabanına Ekle
            await _shipmentCollection.InsertOneAsync(shipment);

            // --- OTOMATİK HAREKET (LOG) MOTORU ---
            try
            {
                // Çıkış şubesinin adını veritabanından sorgula
                var branch = await _branchCollection.Find(x => x.BranchId == createShipmentDto.OriginBranchId).FirstOrDefaultAsync();
                string branchName = branch?.BranchName ?? "Bilinmeyen Şube";

                // İlk hareket DTO'sunu hazırla
                var initialMovement = new CreateShipmentMovementDto
                {
                    ShipmentId = shipment.ShipmentId, // MongoDB'nin insert sonrası ürettiği Id'yi alıyoruz
                    Status = ShipmentStatus.Created,
                    Location = branchName,
                    Description = $"Kargo oluşturuldu - {branchName}",
                    ProcessedByAdminId = null // İleride session'dan çekilen admin Id buraya basılabilir
                };

                // Hareketi otomatik kaydet
                await _shipmentMovementService.CreateMovementAsync(initialMovement);
            }
            catch (Exception ex)
            {
                // Kargo oluştuktan sonra loglama esnasında hata çıkarsa kargo kaydı patlamasın diye catch yapıyoruz
                Console.WriteLine($"İlk hareket logu yazılırken hata oluştu: {ex.Message}");
            }
        }

        public async Task DeleteShipmentAsync(string Id)
        {
            await _shipmentCollection.DeleteOneAsync(x => x.ShipmentId == Id);
        }

        public async Task<List<ResultShipmentDto>> GetAllShipmentAsync()
        {
            var values = await _shipmentCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultShipmentDto>>(values);
        }

        public async Task<GetShipmentByIdDto> GetShipmentByIdAsync(string Id)
        {
            var value = await _shipmentCollection.Find(x => x.ShipmentId == Id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetShipmentByIdDto>(value);

            // NOT: Kargo hareketleri (Movements) bu aşamada null gelir. 
            // Eğer istersen ileride ShipmentMovementCollection'ı buraya enjekte edip
            // hareketleri de bu DTO'nun içine doldurabilirsin.

            return dto;
        }

        public async Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            // 1. Kargoyu bul
            var shipment = await _shipmentCollection.Find(x => x.TrackingNumber == trackingNumber).FirstOrDefaultAsync();

            if (shipment == null) return null;

            // 2. DTO'ya çevir
            var dto = _mapper.Map<GetShipmentByIdDto>(shipment);

            // 3. ŞUBE İSİMLERİNİ BUL VE DTO'YA YAZ (İşte sihir burada!)
            var originBranch = await _branchCollection.Find(x => x.BranchId == shipment.OriginBranchId).FirstOrDefaultAsync();
            var destinationBranch = await _branchCollection.Find(x => x.BranchId == shipment.DestinationBranchId).FirstOrDefaultAsync();

            dto.OriginBranchName = originBranch?.BranchName ?? "Merkez Şube"; // Tablonda şube adı hangi kolondaysa onu yaz (BranchName veya BrandName)
            dto.DestinationBranchName = destinationBranch?.BranchName ?? "Merkez Şube";

            return dto;
        }

        public async Task<List<ResultShipmentDto>> GetShipmentsByBranchIdAsync(string branchId)
        {
            // İlgili şubenin hem "Gönderdiği" hem de "Teslim Alacağı" kargoları listeler
            var values = await _shipmentCollection.Find(x =>
                x.OriginBranchId == branchId ||
                x.DestinationBranchId == branchId).ToListAsync();

            return _mapper.Map<List<ResultShipmentDto>>(values);
        }

        public async Task<List<ResultShipmentDto>> GetShipmentsByPhoneNumberAsync(string phone)
        {
            // Hem gönderici hem alıcı telefonunda arama yapar (Müşteri hizmetleri için birebir)
            var values = await _shipmentCollection.Find(x =>
                x.SenderPhone == phone ||
                x.ReceiverPhone == phone).ToListAsync();

            return _mapper.Map<List<ResultShipmentDto>>(values);
        }

        public async Task<List<ResultShipmentDto>> GetShipmentsByStatusAsync(ShipmentStatus status)
        {
            var values = await _shipmentCollection.Find(x => x.CurrentStatus == status).ToListAsync();
            return _mapper.Map<List<ResultShipmentDto>>(values);
        }

        public async Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
        {
            // Önce mevcut kargoyu buluyoruz
            var existingShipment = await _shipmentCollection.Find(x => x.ShipmentId == updateShipmentDto.ShipmentId).FirstOrDefaultAsync();

            if (existingShipment != null)
            {
                // Sadece DTO'dan gelen, güncellenmesine izin verdiğimiz alanları eziyoruz
                // (Böylece TrackingNumber veya CreatedDate gibi alanlar bozulmuyor)
                existingShipment.ReceiverName = updateShipmentDto.ReceiverName;
                existingShipment.ReceiverPhone = updateShipmentDto.ReceiverPhone;
                existingShipment.ReceiverCity = updateShipmentDto.ReceiverCity;
                existingShipment.ReceiverDistrict = updateShipmentDto.ReceiverDistrict;
                existingShipment.ReceiverNeighborhood = updateShipmentDto.ReceiverNeighborhood;
                existingShipment.ReceiverAddress = updateShipmentDto.ReceiverAddress;
                existingShipment.DestinationBranchId = updateShipmentDto.DestinationBranchId;
                existingShipment.CurrentStatus = updateShipmentDto.CurrentStatus;
                existingShipment.PaymentStatus = updateShipmentDto.PaymentStatus;
                existingShipment.DeliveryNotes = updateShipmentDto.DeliveryNotes;

                // Lojistik Kuralı: Eğer kargo durumu "Teslim Edildi" olarak güncellendiyse
                // ve teslimat tarihi henüz atılmamışsa, o anki saati damgala.
                if (updateShipmentDto.CurrentStatus == ShipmentStatus.Delivered && existingShipment.ActualDeliveryDate == null)
                {
                    existingShipment.ActualDeliveryDate = DateTime.Now;
                }

                await _shipmentCollection.ReplaceOneAsync(x => x.ShipmentId == updateShipmentDto.ShipmentId, existingShipment);
            }
        }
    }
}
