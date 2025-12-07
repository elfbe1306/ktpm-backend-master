using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.LearningContent
{
    public interface ILearningContentRepository
    {
        Task<Result<LearningContentItem[]>> GetLearningContentsByFolderId(Guid folderId);
        Task<Result<LearningContentItem>> CreateLearningContentWithoutFile(LearningContentTable learningContentObject);
        Task<string> InsertFile(string learningContentId, IFormFile file);
        Task<Result<LearningContentItem>> UpdateLearningContentFileUrl(Guid learningContentId, string publicUrl);
        Task<Result<string>> DeleteLearningContent(Guid contentId);
        Task DeleteFile(string contentId);
    }
}