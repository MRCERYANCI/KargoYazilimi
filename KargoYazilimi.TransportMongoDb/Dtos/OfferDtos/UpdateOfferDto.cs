namespace KargoYazilimi.TransportMongoDb.Dtos.OfferDtos
{
    public class UpdateOfferDto
    {
        public string OfferId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public string IconUrl { get; set; }
        public string? Slug { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
