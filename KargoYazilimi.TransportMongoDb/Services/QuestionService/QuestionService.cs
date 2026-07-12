using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.QuestionDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IMongoCollection<Question> _questionCollection;
        private readonly IMapper _mapper;

        public QuestionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _questionCollection = database.GetCollection<Question>(_databaseSettings.QuestionCollectionName);

            _mapper = mapper;
        }

        public async Task CreateQuestionAsync(CreateQuestionDto createQuestionDto)
        {
            var valueMapper = _mapper.Map<Question>(createQuestionDto);
            await _questionCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteQuestionAsync(string Id)
        {
            await _questionCollection.DeleteOneAsync(x => x.QuestionId == Id);
        }

        public async Task<List<ResultQuestionDto>> GetAllQuestionAsync()
        {
            var values = await _questionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultQuestionDto>>(values); ;
        }

        public async Task<GetQuestionByIdDto> GetQuestionByIdAsync(string Id)
        {
            var value = await _questionCollection.Find(x => x.QuestionId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetQuestionByIdDto>(value);
        }

        public async Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto)
        {
            var value = _mapper.Map<Question>(updateQuestionDto);
            await _questionCollection.FindOneAndReplaceAsync(x => x.QuestionId == updateQuestionDto.QuestionId, value);
        }
    }
}
