using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContentFolder;

namespace ktpm_backend_master.Repositories.LearningContentFolder
{
    public interface ILearningContentFolderRepository
    {
        Task<Result<LearningContentFolderItem[]>> GetAllLearningContentFolder(Guid courseId);
        Task<Result<LearningContentFolderItem>> CreateLearningContentFolder(Guid courseId, string topic);
    }
}