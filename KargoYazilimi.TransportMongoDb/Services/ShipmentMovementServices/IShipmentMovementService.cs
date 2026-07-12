using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;

namespace KargoYazilimi.TransportMongoDb.Services.ShipmentMovementServices
{
    public interface IShipmentMovementService
    {
        Task CreateMovementAsync(CreateShipmentMovementDto createShipmentMovementDto);
        Task<List<ResultShipmentMovementDto>> GetMovementsByShipmentIdAsync(string shipmentId);
    }
}
