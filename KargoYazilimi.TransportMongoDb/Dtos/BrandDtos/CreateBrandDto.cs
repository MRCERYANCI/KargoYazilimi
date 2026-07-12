namespace KargoYazilimi.TransportMongoDb.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
