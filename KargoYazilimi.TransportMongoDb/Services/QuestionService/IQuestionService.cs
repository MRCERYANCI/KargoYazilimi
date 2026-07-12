using KargoYazilimi.TransportMongoDb.Dtos.QuestionDtos;

namespace KargoYazilimi.TransportMongoDb.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<List<ResultQuestionDto>> GetAllQuestionAsync();
        Task CreateQuestionAsync(CreateQuestionDto createQuestionDto);
        Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto);
        Task<GetQuestionByIdDto> GetQuestionByIdAsync(string Id);
        Task DeleteQuestionAsync(string Id);
    }
}
