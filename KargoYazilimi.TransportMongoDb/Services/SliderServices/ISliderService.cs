using KargoYazilimi.TransportMongoDb.Dtos.SliderDtos;

namespace KargoYazilimi.TransportMongoDb.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task<GetSldierByIdDto> GetSldierByIdAsync(string Id);
        Task DeleteSliderAsync(string Id);
    }
}
