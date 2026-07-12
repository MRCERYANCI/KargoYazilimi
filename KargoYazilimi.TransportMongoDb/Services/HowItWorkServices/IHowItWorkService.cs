using KargoYazilimi.TransportMongoDb.Dtos.HowItWorkDtos;

namespace KargoYazilimi.TransportMongoDb.Services.HowItWorkServices
{
    public interface IHowItWorkService
    {
        Task<List<ResultHowItWorkDto>> GetAllHowItWorkAsync();
        Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto);
        Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto);
        Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string Id);
        Task DeleteHowItWorkAsync(string Id);
    }
}
