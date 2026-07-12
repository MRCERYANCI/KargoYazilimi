using KargoYazilimi.TransportMongoDb.Dtos.AboutDtos;

namespace KargoYazilimi.TransportMongoDb.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<GetAboutByIdDto> GetSldierByIdAsync(string Id);
        Task DeleteAboutAsync(string Id);
    }
}
