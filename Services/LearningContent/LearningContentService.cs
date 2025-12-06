using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.Models;
using ktpm_backend_master.Repositories.LearningContent;

namespace ktpm_backend_master.Services.LearningContent
{
    public class LearningContentService : ILearningContentService
    {
        private readonly ILearningContentRepository _learningContentRepository;

        public LearningContentService(ILearningContentRepository learningContentRepository)
        {
            _learningContentRepository = learningContentRepository;
        }

        public async Task<Result<LearningContentItem>> CreateLearningContent(string folderId, CreateLearningContentRequest request)
        {
            var newRequest = new LearningContentTable
            {
                Topic = request.Topic,
                Description = request.Description,
                TypeContent = request.TypeContent,
                Url = request.Url,
                LearningContentFolderId = Guid.Parse(folderId),
                CreatedAt = DateTime.UtcNow.ToString()
            };
            var response = await _learningContentRepository.CreateLearningContentWithoutFile(newRequest);
            return response;
        }
    }
}