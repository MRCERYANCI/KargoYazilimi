using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.CareerApplicationDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.CareerApplicationServices
{
    public class CareerApplicationService : ICareerApplicationService
    {

        private readonly IMongoCollection<CareerApplication> _careerApplicationCollection;
        private readonly IMapper _mapper;

        public CareerApplicationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _careerApplicationCollection = database.GetCollection<CareerApplication>(_databaseSettings.CareerApplicationCollectionName);

            _mapper = mapper;
        }
        public async Task CreateCareerApplicationAsync(CreateCareerApplicationDto createCareerApplicationDto)
        {
            var value = _mapper.Map<CareerApplication>(createCareerApplicationDto);

            if (createCareerApplicationDto.CVFile != null && createCareerApplicationDto.CVFile.Length > 0)
            {
                // 1. İstediğin formatta tarih dizini oluştur: /2026/03/13/
                var year = DateTime.Now.ToString("yyyy");
                var month = DateTime.Now.ToString("MM");
                var day = DateTime.Now.ToString("dd");

                // Klasör yapısı: 2026/03/13
                var datePath = Path.Combine(year, month, day);

                // Fiziksel Kayıt Yolu (Sunucu için): wwwroot/uploads-careers/2026/03/13/
                var uploadRoot = Path.Combine("wwwroot", "uploads-careers", datePath);

                if (!Directory.Exists(uploadRoot))
                {
                    Directory.CreateDirectory(uploadRoot);
                }

                // 2. Dosya adını oluştur (GUID ile benzersiz yap)
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(createCareerApplicationDto.CVFile.FileName);

                // Fiziksel olarak dosyayı yaz
                var fullPath = Path.Combine(uploadRoot, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await createCareerApplicationDto.CVFile.CopyToAsync(stream);
                }

                // 3. VERİTABANI YOLU (Senin istediğin format)
                // Sonuç: /uploads-careers/2026/03/13/c758d82c...pdf
                value.CVPath = $"/uploads-careers/{year}/{month}/{day}/{fileName}";
            }

            value.AppliedAt = DateTime.Now;
            value.Status = "Beklemede";
            value.IsReviewed = false;

            await _careerApplicationCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultCareerApplicationDto>> GetAllCareerApplicationAsync()
        {
            var values = await _careerApplicationCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCareerApplicationDto>>(values);
        }

        public async Task<GetCareerApplicationByIdDto> GetCareerApplicationByIdAsync(string Id)
        {
            var value = await _careerApplicationCollection.Find(x => x.CareerApplicationId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetCareerApplicationByIdDto>(value);
        }

        public async Task DeleteCareerApplicationAsync(string Id)
        {
            // İpucu: Silerken fiziksel dosyayı da silebilirsin ama genelde veritabanından silmek yeterli görülür.
            await _careerApplicationCollection.DeleteOneAsync(x => x.CareerApplicationId == Id);
        }

        public async Task UpdateCareerApplicationAsync(UpdateCareerApplicationDto updateCareerApplicationDto)
        {
            var value = _mapper.Map<CareerApplication>(updateCareerApplicationDto);
            await _careerApplicationCollection.FindOneAndReplaceAsync(x => x.CareerApplicationId == updateCareerApplicationDto.CareerApplicationId, value);
        }
    }
}
