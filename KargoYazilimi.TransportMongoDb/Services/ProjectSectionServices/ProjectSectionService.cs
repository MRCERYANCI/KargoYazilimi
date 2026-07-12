using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.ProjectSectionDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace KargoYazilimi.TransportMongoDb.Services.ProjectSectionServices
{
    public class ProjectSectionService : IProjectSectionService
    {
        private readonly IMongoCollection<ProjectSection> _projectSectionCollection;
        private readonly IMapper _mapper;

        public ProjectSectionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _projectSectionCollection = database.GetCollection<ProjectSection>(_databaseSettings.ProjectSectionCollectionName);

            _mapper = mapper;
        }

        public async Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto)
        {
            var valueMapper = _mapper.Map<ProjectSection>(createProjectSectionDto);
            await _projectSectionCollection.InsertOneAsync(valueMapper);
        }

        public async Task DeleteProjectSectionAsync(string Id)
        {
            await _projectSectionCollection.DeleteOneAsync(x => x.ProjectSectionId == Id);
        }

        public async Task<List<ResultProjectSectionDto>> GetAllProjectSectionAsync()
        {
            var values = await _projectSectionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProjectSectionDto>>(values); ;
        }

        public async Task<GetProjectSectionByIdDto> GetProjectSectionByIdAsync(string Id)
        {
            var value = await _projectSectionCollection.Find(x => x.ProjectSectionId == Id).FirstOrDefaultAsync();
            return _mapper.Map<GetProjectSectionByIdDto>(value);
        }

        public async Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto)
        {
            var value = _mapper.Map<ProjectSection>(updateProjectSectionDto);
            await _projectSectionCollection.FindOneAndReplaceAsync(x => x.ProjectSectionId == updateProjectSectionDto.ProjectSectionId, value);
        }

        public async Task<GetProjectSectionBySlugDto> GetProjectSectionBySlugAsync(string slug)
        {
            var values = await _projectSectionCollection.Find(x => x.Slug == slug).FirstOrDefaultAsync();

            return _mapper.Map<GetProjectSectionBySlugDto>(values);
        }
    }
}
