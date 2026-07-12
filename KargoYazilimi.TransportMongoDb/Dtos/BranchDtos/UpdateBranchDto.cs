namespace KargoYazilimi.TransportMongoDb.Dtos.BranchDtos
{
    public class UpdateBranchDto
    {
        public string BranchId { get; set; }

        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchType { get; set; }

        public string City { get; set; }
        public string District { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string ManagerName { get; set; }

        // Harita koordinatları
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
