
using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.GetInTouchSectionDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.GetInTouchSectionServices
{
    public class GetInTouchSectionService : IGetInTouchSectionService
    {
        private readonly IMongoCollection<GetInTouchSection> _getInTouchSectionCollection;
        private readonly IMapper _mapper;

        public GetInTouchSectionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _getInTouchSectionCollection = database.GetCollection<GetInTouchSection>(_databaseSettings.GetInTouchSectionCollectionName);

            _mapper = mapper;
        }

        public async Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto)
        {
            var valueMapper = _mapper.Map<GetInTouchSection>(createGetInTouchSectionDto);
            await _getInTouchSectionCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteGetInTouchSectionAsync(string Id)
        {
            await _getInTouchSectionCollection.DeleteOneAsync(x => x.GetInTouchSectionId == Id);
        }

        public async Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionAsync()
        {
            var values = await _getInTouchSectionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGetInTouchSectionDto>>(values); ;
        }

        public async Task<GetGetInTouchSectionByIdDto> GetInTouchSectionByIdAsync(string Id)
        {
            var value = await _getInTouchSectionCollection.Find(x => x.GetInTouchSectionId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetGetInTouchSectionByIdDto>(value);
        }

        public async Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto)
        {
            var value = _mapper.Map<GetInTouchSection>(updateGetInTouchSectionDto);
            await _getInTouchSectionCollection.FindOneAndReplaceAsync(x => x.GetInTouchSectionId == updateGetInTouchSectionDto.GetInTouchSectionId, value);
        }
    }
}
