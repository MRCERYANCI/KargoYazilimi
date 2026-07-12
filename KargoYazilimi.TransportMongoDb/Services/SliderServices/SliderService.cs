using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.SliderDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.SliderServices
{
    public class SliderService : ISliderService
    {

        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//ConnectionString'de Bağlantı Adresini Tutuyoruz
            var database = client.GetDatabase(_databaseSettings.Databasename);//Client'taki bağlantı üzerinden Veritabanı Adını Aldık
            _sliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);//Database Aracı İle Slider Sınıfını Aldık
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var valueMapper = _mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteSliderAsync(string Id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderId == Id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task<GetSldierByIdDto> GetSldierByIdAsync(string Id)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetSldierByIdDto>(value);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, value);
        }
    }
}
