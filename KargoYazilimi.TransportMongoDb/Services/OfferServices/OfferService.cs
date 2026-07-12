using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.OfferDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _offerCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName);

            _mapper = mapper;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var valueMapper = _mapper.Map<Offer>(createOfferDto);
            await _offerCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteOfferAsync(string Id)
        {
            await _offerCollection.DeleteOneAsync(x => x.OfferId == Id);
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDto>>(values); ;
        }

        public async Task<GetOfferByIdDto> GetOfferBySlugAsync(string slug)
        {
            // MongoDB'de Slug alanına göre eşleşen ilk kaydı buluyoruz
            var value = await _offerCollection.Find(x => x.Slug == slug).FirstOrDefaultAsync();

            // Eğer kayıt bulunamazsa null döner, bulunduysa DTO'ya map'leyip göndeririz
            return _mapper.Map<GetOfferByIdDto>(value);
        }

        public async Task<GetOfferByIdDto> GetSldierByIdAsync(string Id)
        {
            var value = await _offerCollection.Find(x => x.OfferId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferByIdDto>(value);
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var value = _mapper.Map<Offer>(updateOfferDto);
            await _offerCollection.FindOneAndReplaceAsync(x => x.OfferId == updateOfferDto.OfferId, value);
        }
    }
}
