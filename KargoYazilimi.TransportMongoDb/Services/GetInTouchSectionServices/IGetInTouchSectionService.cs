using KargoYazilimi.TransportMongoDb.Dtos.GetInTouchSectionDtos;

namespace KargoYazilimi.TransportMongoDb.Services.GetInTouchSectionServices
{
    public interface IGetInTouchSectionService
    {
        Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionAsync();
        Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto);
        Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto);
        Task<GetGetInTouchSectionByIdDto> GetInTouchSectionByIdAsync(string Id);
        Task DeleteGetInTouchSectionAsync(string Id);
    }
}
