namespace KargoYazilimi.TransportMongoDb.Dtos.ProjectSectionDtos
{
    public class GetProjectSectionBySlugDto
    {
        public string ProjectSectionId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
