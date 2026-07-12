using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.AboutDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _brandCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _brandCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);

            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var valueMapper = _mapper.Map<About>(createAboutDto);
            await _brandCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteAboutAsync(string Id)
        {
            await _brandCollection.DeleteOneAsync(x => x.AboutId == Id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values); ;
        }

        public async Task<GetAboutByIdDto> GetSldierByIdAsync(string Id)
        {
            var value = await _brandCollection.Find(x => x.AboutId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetAboutByIdDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, value);
        }
    }
}
