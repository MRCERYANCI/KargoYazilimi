using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.BranchDtos;
using KargoYazilimi.TransportMongoDb.Dtos.BrandDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IMongoCollection<Branch> _branchCollection;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _branchCollection = database.GetCollection<Branch>(_databaseSettings.BranchCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultBranchDto>> GetAllBranchAsync()
        {
            var values = await _branchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranchDto>>(values);
        }

        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            var value = _mapper.Map<Branch>(createBranchDto);
            await _branchCollection.InsertOneAsync(value);
        }

        public async Task DeleteBranchAsync(string id)
        {
            await _branchCollection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task UpdateBranchAsync(UpdateBranchDto updateBranchDto)
        {
            var value = _mapper.Map<Branch>(updateBranchDto);
            await _branchCollection.FindOneAndReplaceAsync(x => x.BranchId == updateBranchDto.BranchId, value);
        }

        public async Task<GetBranchByIdDto> GetByIdBranchAsync(string id)
        {
            var value = await _branchCollection.Find(x => x.BranchId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBranchByIdDto>(value);
        }
    }
}
