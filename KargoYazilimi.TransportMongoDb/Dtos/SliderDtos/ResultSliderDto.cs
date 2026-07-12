namespace KargoYazilimi.TransportMongoDb.Dtos.SliderDtos
{
    public class ResultSliderDto
    {
        public string SliderId { get; set; }
        public string? SmallTitle { get; set; }
        public string? MainTitle { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Button1Text { get; set; }
        public string? Button1Url { get; set; }
        public string? VideoUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
