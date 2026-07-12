namespace KargoYazilimi.TransportMongoDb.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Databasename { get; set; }
        public string SliderCollectionName { get; set; }
        public string BrandCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string GetInTouchSectionCollectionName { get; set; }
        public string CareerApplicationCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string HowItWorkCollectionName { get; set; }
        public string QuestionCollectionName { get; set; }
        public string ProjectSectionCollectionName { get; set; }
        public string BranchCollectionName { get; set; }
        public string AdminCollectionName { get; set; }
        public string ShipmentCollectionName { get; set; }
        public string ShipmentMovementCollectionName { get; set; }

    }
}
