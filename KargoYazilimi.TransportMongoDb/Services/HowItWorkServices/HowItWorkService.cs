using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.HowItWorkDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.HowItWorkServices
{
    public class HowItWorkService : IHowItWorkService
    {
        private readonly IMongoCollection<HowItWork> _howItWorkCollection;
        private readonly IMapper _mapper;

        public HowItWorkService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _howItWorkCollection = database.GetCollection<HowItWork>(_databaseSettings.HowItWorkCollectionName);

            _mapper = mapper;
        }

        public async Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto)
        {
            var valueMapper = _mapper.Map<HowItWork>(createHowItWorkDto);
            await _howItWorkCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteHowItWorkAsync(string Id)
        {
            await _howItWorkCollection.DeleteOneAsync(x => x.HowItWorkId == Id);
        }

        public async Task<List<ResultHowItWorkDto>> GetAllHowItWorkAsync()
        {
            var values = await _howItWorkCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultHowItWorkDto>>(values); ;
        }

        public async Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string Id)
        {
            var value = await _howItWorkCollection.Find(x => x.HowItWorkId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetHowItWorkByIdDto>(value);
        }

        public async Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto)
        {
            var value = _mapper.Map<HowItWork>(updateHowItWorkDto);
            await _howItWorkCollection.FindOneAndReplaceAsync(x => x.HowItWorkId == updateHowItWorkDto.HowItWorkId, value);
        }
    }
}
