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
            if (request.TypeContent != "video" && request.File == null)
                return Result<LearningContentItem>.Fail("File is required for this content type.");
                
            var newContent = new LearningContentTable
            {
                Topic = request.Topic,
                Description = request.Description,
                TypeContent = request.TypeContent,
                Url = request.Url,
                LearningContentFolderId = Guid.Parse(folderId),
                CreatedAt = DateTime.UtcNow.ToString()
            };

            var insertContent = await _learningContentRepository.CreateLearningContentWithoutFile(newContent);
            if (request.TypeContent == "video")
            {
                return insertContent;
            }

            var insertedId = insertContent?.Data?.Id;
            if (insertedId == null) return Result<LearningContentItem>.Fail("Missing Learning Content Id");
            if (request.File == null) return Result<LearningContentItem>.Fail("File is required for this content type.");

            var insertFileUrl = await _learningContentRepository.InsertFile(insertedId, request.File);

            var final = await _learningContentRepository.UpdateLearningContentFileUrl(Guid.Parse(insertedId), insertFileUrl);

            return final;
        }
    }
}