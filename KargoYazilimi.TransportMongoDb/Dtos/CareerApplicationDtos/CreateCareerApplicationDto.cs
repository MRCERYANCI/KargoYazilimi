namespace KargoYazilimi.TransportMongoDb.Dtos.CareerApplicationDtos
{
    public class CreateCareerApplicationDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string LicenseClass { get; set; }
        public string ExperienceYear { get; set; }
        public string MilitaryStatus { get; set; }
        public string CoverLetter { get; set; }
        public IFormFile CVFile { get; set; }
        public string? CVPath { get; set; }
    }
}
