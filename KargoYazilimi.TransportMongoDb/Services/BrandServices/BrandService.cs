using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.BrandDtos;
using KargoYazilimi.TransportMongoDb.Dtos.SliderDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);

            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var valueMapper = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteBrandAsync(string Id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandId == Id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values); ;
        }

        public async Task<GetBrandByIdDto> GetBrandByIdAsync(string Id)
        {
            var value = await _brandCollection.Find(x => x.BrandId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetBrandByIdDto>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, value);
        }
    }
}
