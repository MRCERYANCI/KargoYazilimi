using KargoYazilimi.TransportMongoDb.Dtos.ProjectSectionDtos;

namespace KargoYazilimi.TransportMongoDb.Services.ProjectSectionServices
{
    public interface IProjectSectionService
    {
        Task<List<ResultProjectSectionDto>> GetAllProjectSectionAsync();
        Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto);
        Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto);
        Task<GetProjectSectionByIdDto> GetProjectSectionByIdAsync(string Id);
        Task DeleteProjectSectionAsync(string Id);
        Task<GetProjectSectionBySlugDto> GetProjectSectionBySlugAsync(string slug);
    }
}
