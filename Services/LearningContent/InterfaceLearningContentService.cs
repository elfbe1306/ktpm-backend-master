using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;

namespace ktpm_backend_master.Services.LearningContent
{
    public interface ILearningContentService
    {
        Task<Result<LearningContentItem>> CreateLearningContent(string folderId, CreateLearningContentRequest request);
        Task<Result<string>> DeleteLearningContent(string contentId, string typeContent);
    }
}