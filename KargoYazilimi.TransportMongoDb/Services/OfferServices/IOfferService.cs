using KargoYazilimi.TransportMongoDb.Dtos.OfferDtos;

namespace KargoYazilimi.TransportMongoDb.Services.OfferServices
{
    public interface IOfferService
    {
        Task<List<ResultOfferDto>> GetAllOfferAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task<GetOfferByIdDto> GetSldierByIdAsync(string Id);
        Task DeleteOfferAsync(string Id);
        Task<GetOfferByIdDto> GetOfferBySlugAsync(string slug);
    }
}
