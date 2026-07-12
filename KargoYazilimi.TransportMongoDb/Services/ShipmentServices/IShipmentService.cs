using KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos;
using static KargoYazilimi.TransportMongoDb.Entities.Enums;

namespace KargoYazilimi.TransportMongoDb.Services.ShipmentServices
{
    public interface IShipmentService
    {
        Task<List<ResultShipmentDto>> GetAllShipmentAsync();
        Task CreateShipmentAsync(CreateShipmentDto createShipmentDto);
        Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto);
        Task<GetShipmentByIdDto> GetShipmentByIdAsync(string Id);
        Task DeleteShipmentAsync(string Id);
        Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(string trackingNumber);
        Task<List<ResultShipmentDto>> GetShipmentsByBranchIdAsync(string branchId);
        Task<List<ResultShipmentDto>> GetShipmentsByStatusAsync(ShipmentStatus status);
        Task<List<ResultShipmentDto>> GetShipmentsByPhoneNumberAsync(string phone);
    }
}
