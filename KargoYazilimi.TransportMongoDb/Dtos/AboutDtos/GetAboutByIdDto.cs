namespace KargoYazilimi.TransportMongoDb.Dtos.AboutDtos
{
    public class GetAboutByIdDto
    {
        public string AboutId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 
        public string IconUrl { get; set; } 
        public List<string> Features { get; set; } 
        public bool IsActive { get; set; }
    }
}
