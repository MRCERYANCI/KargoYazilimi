using KargoYazilimi.TransportMongoDb.Dtos.BrandDtos;

namespace KargoYazilimi.TransportMongoDb.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<GetBrandByIdDto> GetBrandByIdAsync(string Id);
        Task DeleteBrandAsync(string Id);
    }
}
