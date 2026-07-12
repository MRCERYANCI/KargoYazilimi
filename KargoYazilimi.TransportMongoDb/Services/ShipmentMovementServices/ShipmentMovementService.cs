using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices
{
    public class ShipmentMovementService : IShipmentMovementService
    {
        private readonly IMongoCollection<ShipmentMovement> _movementCollection;
        private readonly IMapper _mapper;

        public ShipmentMovementService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _movementCollection = database.GetCollection<ShipmentMovement>(_databaseSettings.ShipmentMovementCollectionName);
            _mapper = mapper;
        }

        public async Task CreateMovementAsync(CreateShipmentMovementDto createShipmentMovementDto)
        {
            var movement = _mapper.Map<ShipmentMovement>(createShipmentMovementDto);

            // Tarihi veritabanına yazılırken milisaniyelik hassasiyetle otomatik atıyoruz
            movement.ProcessDate = DateTime.Now;

            await _movementCollection.InsertOneAsync(movement);
        }

        public async Task<List<ResultShipmentMovementDto>> GetMovementsByShipmentIdAsync(string shipmentId)
        {
            // Hareketleri çekerken eskiden yeniye doğru (kronolojik) sıralayarak getiriyoruz
            var values = await _movementCollection.Find(x => x.ShipmentId == shipmentId)
                                                 .SortBy(x => x.ProcessDate)
                                                 .ToListAsync();

            return _mapper.Map<List<ResultShipmentMovementDto>>(values);
        }
    }
}
