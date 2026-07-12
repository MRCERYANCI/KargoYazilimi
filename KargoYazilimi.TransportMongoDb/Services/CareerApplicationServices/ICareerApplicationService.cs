using KargoYazilimi.TransportMongoDb.Dtos.CareerApplicationDtos;

namespace KargoYazilimi.TransportMongoDb.Services.CareerApplicationServices
{
    public interface ICareerApplicationService
    {
        Task<List<ResultCareerApplicationDto>> GetAllCareerApplicationAsync();
        Task CreateCareerApplicationAsync(CreateCareerApplicationDto createCareerApplicationDto);
        Task UpdateCareerApplicationAsync(UpdateCareerApplicationDto updateCareerApplicationDto);
        Task<GetCareerApplicationByIdDto> GetCareerApplicationByIdAsync(string Id);
        Task DeleteCareerApplicationAsync(string Id);
    }
}
