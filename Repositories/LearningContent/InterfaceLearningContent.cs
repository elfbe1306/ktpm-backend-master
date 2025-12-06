using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.LearningContent
{
    public interface ILearningContentRepository
    {
        Task<Result<LearningContentItem[]>> GetLearningContentsByFolderId(Guid folderId);
        Task<Result<LearningContentItem>> CreateLearningContentWithoutFile(LearningContentTable learningContentObject);
    }
}