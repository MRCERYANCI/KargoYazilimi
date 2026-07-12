namespace KargoYazilimi.TransportMongoDb.Dtos.BrandDtos
{
    public class ResultBrandDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
