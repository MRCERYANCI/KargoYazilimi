using KargoYazilimi.TransportMongoDb.Dtos.BranchDtos;

namespace KargoYazilimi.TransportMongoDb.Services.BranchService
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> GetAllBranchAsync();
        Task CreateBranchAsync(CreateBranchDto createBranchDto);
        Task DeleteBranchAsync(string id);
        Task<GetBranchByIdDto> GetByIdBranchAsync(string id);
        Task UpdateBranchAsync(UpdateBranchDto updateBranchDto);
    }
}
