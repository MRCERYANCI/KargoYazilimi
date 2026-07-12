using KargoYazilimi.TransportMongoDb.Dtos.TestimonialDtos;

namespace KargoYazilimi.TransportMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string Id);
        Task DeleteTestimonialAsync(string Id);
    }
}
