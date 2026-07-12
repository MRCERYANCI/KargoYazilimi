namespace KargoYazilimi.TransportMongoDb.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string TestimonialId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public int StarCount { get; set; }
        public double RatingScore { get; set; }
        public bool IsActive { get; set; }
        public int OrderNo { get; set; }
    }
}
